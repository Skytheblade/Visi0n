﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model_;

namespace VModel_
{
    public class UserService
    {
        // general login control on base form
        public static bool LoginAtt(string usrname, string pass, int type_ = 1)
        {
            User usr = FindUser(usrname);

            if (usr._usrName == usrname && usr._pwd == pass && (usr._type == type_ || usr._type == 3)) return true;
            return false;
        }

        public static User FindUser(string usrName) => (User)(new UserDB().TargetSelect(new UserDB().FindID(usrName)));

        public static int FindUserID(string usrName) => FindUser(usrName)._absId;

        public static User Get(int id = 2) // get user with id
        {
            UserDB usrdb = new UserDB();
            User usr = (User)(usrdb.TargetSelect(id));
            if (usr._absId == id) return usr;
            else return null;
        }

        public static User MakeUser(string usrN, string pass, int ty)
        {
            User uu = new User(usrN, pass, NextId(), ty);

            new UserDB().Insert(uu);

            return uu;
        }

        public static int NextId()
        {
            List<Entity> ul = new UserDB().SelectAll();
            int iid = 0;
            foreach (User u in ul)
            {
                if (iid <= u._absId) iid = u._absId;
            }
            iid++;
            return iid;
        }




        public static bool Verify(User u)
        {
            if (u._absId > 0) return true; else return false;
        }


        public static Person Persona(User u) => (Person)(new PersonalDB().TargetSelect(u._absId)); // get (person)u raw

        public static Corp LaEmpressa(User u) => (Corp)(new CorpDB().TargetSelect(u._absId)); // get (corp)u raw


        public static Person LaPersona(User u, Person p = null) // returns the full (besides type) person of user if valid | (Person)u
        {
            Person pu = Persona(u);
            if (Verify(pu)) return pu;
            else return p;
        }

        public static Corp Corporative(User u, Corp cc = null) // returns if the user is corp the corporation | (Corp)u
        {
            Corp cu = LaEmpressa(u);
            if (Verify(cu)) return cu;
            else return cc;
        }


        public static Corp UnGroupe(Person p) => new CorpDB().Call(p._cid); // returns the corp containing user if is

        public static List<Person> LaCampanella(Corp c) // returns all people in a corp
        {
            List<Entity> el = new PersonalDB().SelectAll();
            List<Person> people = new List<Person>();
            foreach (Person p in el) { if (p._cid == c._cid) people.Add(p); }
            return people;
        }


        public static string CorpNameID(string cid) => new CorpDB().Call(cid)._cName; // get name per id



        public static void CreatePerson(User u, string f, string l, string c)
        {
            Person p = new Person(u, f, l, c);
            new PersonalDB().Insert(p);
        }

        public static void CreateCorp(User u, string cid, string cn)
        {
            Corp cc = new Corp(u, cid, cn);
            new CorpDB().Insert(cc);
        }
    }
}

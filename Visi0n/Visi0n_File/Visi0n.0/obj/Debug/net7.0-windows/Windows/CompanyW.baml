   M S B A M L   `   `   `  ����C  ?Visi0n.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Visi0n._0	Visi0n._0  5   	       Visi0n._0.CompanyW   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Visi0n._0     5   	   -   5          � Title$  Visi0n - Company��5   	   $	��450��6"   $	��800��6/   $	��450��5	   	   $	��800��6    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��8* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      $	��33* �6   .+�5   
   �� -   5         ��Name$ ControlButtons��5      $��5q�6-    �� Orientation$ 
Horizontal=�68   $��RightToLeft=�6Q   $��1��6m   $��0��6}   .+�5      �� -   5         ��Name$
 Quit��5      $��65��6#   $
��Quit��6.   $	��3,0q�6=   6J   �� 5      -   5        $ LogOut��5      $��65��6%   $��Log Out��60   $	��3,0q�6B   6O   5      �� 5   
   -   5        $ ActionButtons��5      $��5q�6,   $ 
Horizontal=�67   $��LeftToRight=�6P   $��0��6l   $��0��6|   .+�5      � -   5         �Name$ Stats��5      $	��120��6"   $
��12,3q�6.   .+�5      �� $ Vertical=�6   $��LeftToRight=�64   .+�5      �� -   5        	 ��Name$	 CompanyNameLabel��5      $��Company Name��66   $��11(�6M   $
��Bold"�6[   6o   �� 5      -   5        $	 currentStateLabel��5      $��	Current: ��67   $��11(�6K   $
��Bold"�6Y   6m   5       5!      �� 5"      -	   5        $ CompanyDetailsB��5"      $��65��6.   $��Details��69   $	��3,0q�6K   6X   �� 5#      -
   5        $ 	CalendarB��5#      $��65��6(   $��Calendar��63   $	��3,0q�6F   6S   �� 5$      -   5        $ NotesB��5$      $��65��6%   $��Notes��60   $	��3,0q�6@   6M   �� 5%      -   5        $ 
RemindersB��5%      $��65��6)   $��	Reminders��64   $	��3,0q�6H   6U   �� 5&      -   5        $ SelfPB��5&      $��65��6%   $
��Self��60   $	��3,0q�6?   6L   5'      � 5(   
   -   5        $ 	MainPanel��5(      $��5q�6"   $��2��6-   $��1��6A   .+�5)       � -   5        
  �Name$
 Screen��5)        � NavigationUIVisibility$ Hidden=�6$   5+      5,      5-      5.      
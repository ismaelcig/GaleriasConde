   M S B A M L   `   `   `  ����P  LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls  5   	   B >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Galeria.User_Controls.Management_Windows(Galeria.User_Controls.Management_Windows 5   	      Galeria.Windows.A_Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   /metro#http://schemas.codeplex.com/elysium   5   	   7params*http://schemas.codeplex.com/elysium/params   5   	   OManagement_Windows6clr-namespace:Galeria.User_Controls.Management_Windows   5   	      Elysium.Parameters.Design    Theme$  LightX�5	   	       Elysium.Parameters.Manager   Theme$ LightX�5
   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	      CloseApp   Elysium.Parameters.Window   CloseButtonToolTip# �   5   	     MinimizeApp   MinimizeButtonToolTip# �  5   	    � WindowStartupLocation$ CenterScreen=�5   	     MWtitle � Title# �  5   	   $	��150��6+   $	��308��68    � 
ResizeMode$ CanMinimize=�6D   	 � 	Resources	 5      
 �� 
TargetType  MaterialDesignTextBox �� BasedOn  MaterialDesignPasswordBox��%`   '��       7  'G� "     7  �� 5   
   "
 ��6   8   6.   �� 5   
   "
 G�6   8   62   5      .��5      � .+�5   
   � -   5         �Name$ GridUS��5      .+�5      �� -   5         ��Name$ textBox��5      $
��Left=�6'   $��39��6B   $��	46,20,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��212��6�    	 MWtxt)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6�      FloatingScale$	 0.8Q�6�      
IsFloating . 6,  �� 5       -   5         ��Name$ buttNext��5         Next#���  6'   $
��Left=�6H   $��	46,70,0,0q�6c   $	��Top=�6v   $	��104��6�   6�   �� 5!      -   5        $ buttReg��5!        MWb2#���  6&   $
��Left=�6G   $��
154,70,0,0q�6b   $	��Top=�6v   $	��104��6�   6�   5"      � 5#   
   -   5        $ GridPW��5#      
�������$y�Hidden=�62   .+�5$      G� -   5         G�Name$ passwordBox��5$      $
��Left=�6/   $��	46,20,0,0q�6J   $	��Top=�6]   $��39��6u   $	��212��6�    
 MWpass# �  6�   $	 0.8Q�6�    . 6"  �� 5&      -   5        $ 	buttLogin��5&       	 MWb3#��� 	 6(   $
��Left=�6I   $��	46,70,0,0q�6d   $	��Top=�6w   $	��104��6�   6�   �� 5'      -   5        $ buttBack��5'       
 Back#��� 
 6'   $
��Left=�6H   $��
154,70,0,0q�6c   $	��Top=�6w   $	��104��6�   6�   5(      5,      5-      
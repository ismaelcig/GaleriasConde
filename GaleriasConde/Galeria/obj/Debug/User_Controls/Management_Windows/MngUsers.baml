   M S B A M L   `   `   `  ����B  >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Galeria.User_Controls.Management_Windows(Galeria.User_Controls.Management_Windows  5      P LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls 5   	   =#clr-namespace:Galeria.User_ControlsGaleria.User_Controls  5   	   7    1Galeria.User_Controls.Management_Windows.MngUsers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:Galeria.User_Controls.Management_Windows     5      DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   /metro#http://schemas.codeplex.com/elysium  5
   	   7params*http://schemas.codeplex.com/elysium/params  5   	   7User_Controls#clr-namespace:Galeria.User_Controls  5   	     Elysium.Parameters.Design    Theme$  LightX�5   	      Elysium.Parameters.Manager   Theme$ LightX�5   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	   .��5      � 
�������.+�5   
   �� ���#688CAF$��1q�6'   $
��Auto��6;   $
��Auto��6H   ._�5      � .+�5      �� -   5         ��Name$ txtUser��5      {�.  $
��Left=�6=   $��40��6X   $��	21,10,0,0q�6d    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��199��6�    	  mdTxt#��[  6�     User)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6�      
IsFloating .    FloatingScale$	 0.8Q�62  #  Elysium.Controls.ToggleSwitch  5      -   5        	  Name$	 checkBox��5   %   $
��Left=�67   $��	20,64,0,0q�6R   $	��Top=�6e   �� 5      -   5        
 ��Name$
 label1��5       	 Admin#���  6(   $
��Left=�6J   $��	75,58,0,0q�6e   $	��Top=�6x   �� 5       -   5         ��Name$ buttMod��5        
 CG4Mod#���  6*   $
��Left=�6M   $��
15,113,0,0q�6h   $	��Top=�6|   $��95��6�   6�   �� 5!      -   5        $ buttDel��5!       
 CG4Del#���  6*   $
��Left=�6M   $��135,113,0,0q�6h   $	��Top=�6}   $��95��6�   6�   5"      5#      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ dataGrid��5$      $��Stretch=�6%   $��	240,0,0,0q�6C   $��Stretch=�6V     dg#��[ 6�    � DataContext 6r   ��  �� Source$
 User��   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *nick+,  &System.Windows.Controls.DataGridColumn   Header 5'      �� 5(        Nick#���  6$   $��Center=�6B   5*        5+       6%   �� *name+ 5,      �� 5-      #��� ��6$   $��Center=�6B   5/        50       6%   �� *
surnames+ 51      �� 52        Surnames#���  6$   $��Center=�6F   54        55       6%   �� *tlf+ 56      �� 57        Tlf#���  6$   $��Center=�6A   59        5:       6%   �� *email+ 5;      �� 5<       		 Email#��� 	 6$   $��Center=�6C   5>      5B      5C      5D      
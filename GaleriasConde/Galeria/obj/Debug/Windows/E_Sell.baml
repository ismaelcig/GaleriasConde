   M S B A M L   `   `   `  ����B  >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Galeria.WindowsGaleria.Windows  5   	   P LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls 5   	   =#clr-namespace:Galeria.User_ControlsGaleria.User_Controls  5   	       Galeria.Windows.E_Sell   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Galeria.Windows     5   	   DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   /metro#http://schemas.codeplex.com/elysium  5
   	   7params*http://schemas.codeplex.com/elysium/params  5   	   7User_Controls#clr-namespace:Galeria.User_Controls  5   	   -   5          Elysium.Parameters.Design    Theme$  LightX�5   	      Elysium.Parameters.Manager   Theme$ LightX�5   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	      	SELLtitle � Title# �   5   	   $��395.864��6-   $��437.594��6>   .��5      � .+�5   
   � .+�5      �� -   5         ��Name$ txtTitle��5       �� 	MaxLength$	 125��6(   $
��Left=�68   $��40��6S   $��	10,10,0,0q�6_    �� TextWrapping$
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��410��6�    	 Title)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6�   	   
IsFloating	 .  	 mdTxt#��[ 6  �� 5      -   5        
 ��Name$
 comboBoxAut��5      $
��Left=�6,   $��	10,50,0,0q�6G   $	��Top=�6Z   $��40��6r   $	��182��6~    
 Author# �  6�   	 .   mdCombo#��[ 6�   �� 5      -   5        $ txtAut��5      $
��Left=�6&   $��40��6A   $��
197,50,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��223��6�     SAuthor# �  6�   	 . #��[ 6  6'  �� 5      -   5        $
 comboBoxType��5      $
��Left=�6-   $��	10,90,0,0q�6H   $	��Top=�6[   $��40��6s   $	��182��6     Type# �  6�   	 . #��[ 6�   �� 5      -   5        $ txtType��5      $
��Left=�6'   $��40��6B   $��
197,90,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��223��6�   # �  6�   	 . #��[ 6	  6(  �� 5      -   5        $ txtinfo��5      $
��Left=�6'   $��10,130,0,56q�6B   $
 Wrap=�6W   $�� ��6k   $��Stretch=�6s   $	��226��6�    �� AcceptsReturn . $	��Top=�6�    
 SDescr# �  6�   	 . #��[ 65  �� 5      
���   �$��1q�6)   $��245,135,0,0q�6=   $	��175��6R   $	��175��6_   $
��Left=�6k   $	��Top=�6�   ._�5      �� -   5         ��Name$	 img��5      5      �� 5       
���   �$��1q�6)   $��245,135,0,0q�6=   $	��175��6R   $	��175��6_   $
��Left=�6k   $	��Top=�6�   ._�5!      �� -	   5        $ overImg��5!       
 camera#��[ 6)    � Cursor$
 Hand��6J   6�   5"      �� 5#      -
   5         ��Name$ button��5#       	 Sb2#��� 	 6%   $
��Left=�6E   $��166,316,0,0q�6`   $	��Top=�6u   $
��Auto��6�   $��40��6�   6�   5$      5%      5&      
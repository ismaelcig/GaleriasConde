   M S B A M L   `   `   `  ����P  LElysium, Version=2.0.976.4, Culture=neutral, PublicKeyToken=afa220db249e5b15D/clr-namespace:Elysium.Controls;assembly=ElysiumElysium.Controls  5   	   B >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Galeria.User_ControlsGaleria.User_Controls 5   	   ]3clr-namespace:Galeria.User_Controls.Messages_Window%Galeria.User_Controls.Messages_Window 5	   	   c6clr-namespace:Galeria.User_Controls.Management_Windows(Galeria.User_Controls.Management_Windows 5
   	      Galeria.Windows.C_Galeria   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   DControls/clr-namespace:Elysium.Controls;assembly=Elysium     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   /metro#http://schemas.codeplex.com/elysium   5   	   7params*http://schemas.codeplex.com/elysium/params   5   	   7User_Controls#clr-namespace:Galeria.User_Controls   5   	   D
Msg_Window3clr-namespace:Galeria.User_Controls.Messages_Window   5	   	   OManagement_Windows6clr-namespace:Galeria.User_Controls.Management_Windows   5
   	   -   5           Elysium.Parameters.Design    Theme$  LightX�5   	       Elysium.Parameters.Manager   Theme$ LightX�5   	      AccentBrush$ 
BlueViolet��5   	      ContrastBrush$ BlanchedAlmond��5   	   $
��Bold"�5   	   $��15(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	      CloseApp   Elysium.Parameters.Window   CloseButtonToolTip# �   5   	     MaximizeApp   MaximizeButtonToolTip# �  5   	     MinimizeApp   MinimizeButtonToolTip# �  5   	    � WindowStartupLocation$ CenterOwner=�5   	     CGtitle � Title# �  5   	   $	��480��6+   $	��480��68   $	��742��6H   $	��742��6T   	 � 	Resources	 5      
 �� 
TargetType  submenu �� Property �� Value �� Triggers P� Property P� Value  userBut 
 Header��%�  &	       &	 �    &	 y    �� 5   
   "
 ��6   .�5      ��  � ��$ 20(�6)   �� 5        � ��$ SemiBold"�6+   �� 5!       � ��
 ��İ�6+   �� 5"       � ��
 �""��6+   �� 5#       � ��$ 1q�60    5$      P� 5%       �@J�IsMouseOver . . �5&      ��  � ��
 � E��63   �� 5'       � ��$ Black"�63   �� 5(       � ��$ Medium&�64   �� 5)       � ��
 ��Zj�63   5*      5,      �� 5.   
   "
 ��6    5/      P� 50       �@J�IsMouseOver . . �51      ��  � �� �	#FF4474F163   �� 52       � �� �	#FF0D247464   53      55      �� 57   
   "
 ��6   .�58      ��  � ��$X Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�6+   �� 59       � ��$ 20(�6)   �� 5:       � ��
 �   �6+   �� 5;       �@J�Opacity$	 0.7Q�6(   5<      5=      .��5>      �  � RowDefinitions 5?   
   �� 5@      $��36 �6   �� 5A      $
��203* �6   .+�5C   
   �� $��2��6   .@�5D      �� -   5         ��Name$
 Pst1��5D      ��5E      �� 5F      -   5         
 CGpst1#���  5F      #��[ 6]   .��5H      � .+�5I      ]� -   5         ]�Name$ docky��5I       
���\\����. $
��Left=�6[   $��
10,10,5,10q�6v   $��Stretch=�6�   $	��200��6�    K� ZIndex$ 10��6�   .+�5J      �� $��0,0,0,1q�6!   
���   �$��Stretch=�6O   $	��Top=�6m   $��40��6�   $	��Top=�6�   ._�5K      ��  �� Orientation$ 
Horizontal=�6)   
�������.+�5L   "   �� -   5         ��Name$ label��5L   (     	CG1Filter#���  67   $��20(�6]   $	��130��6l   �� 5M   "   -   5         ��Name$ button��5M   )   $��<-��69   $��40��6I   $	��Top=�6U   $��70��6m   $��Right=�6x   6�   5N      5O      �� 5P      -   5         ��Name$ txtSearchArt��5P   "   $��39��68   $��Bottom=�6D    		 mdTxt#��[	 6\   $�� ��6{   $��Bottom=�6�   $	��200��6�    
 	CG1Search)  #MaterialDesignThemes.Wpf.HintAssist   Hint# � 
 6�      FloatingScale$	 0.8Q�6�      
IsFloating .  
�������   AccentBrush$ Black��6U  6w  �� 5R      $��1q�6!   
���   �$��Stretch=�6J   $��Stretch=�6f   ._�5S      � .+�5T   "   �� 
�������$
��Auto=�6B   $��0,0,0,30q�6e   .��5U   &   �� -   5         ��Name$ spFilter��5U   1   $ Vertical=�6C   .+�5V   *   �� $��ZZZZZZZZZZZZZZ��61   $��5q�6J   �� 5W   *   $��ZZZZZZZZZZZZZZ��61   $��5q�6J   �� 5X   *   $��ZZZZZZZZZZZZZZ��61   $��5q�6J   �� 5Y   *   $��ZZZZZZZZZZZZZZ��61   $��5q�6J   �� 5Z   *   $��ZZZZZZZZZZZZZZ��61   $��5q�6J   �� 5[   *   $��ZZZZZZZZZZZZZZ��61   $��5q�6J   5\   '   5]   #   #   Elysium.Controls.ToggleSwitch  5^   "   -	   5          Name$ checkOnStock��5^   5      	IsChecked . $
��Left=�6\   $��Bottom=�6w   $��2,0,0,5q�6�   �� 5_   "     
CG1OnStock#���  6(   $
��Left=�6O   $��Bottom=�6j   $��56,0,0,1q�6�   $
��Bold"�6�   5`      5a      5b      �� 5c      -
   5         ��Name$ MyScrollViewer��5c   #   $
��Auto=�6;   $��Stretch=�6^   $��Stretch=�6|   $��210,10,10,10q�6�   .��5d      -  'Galeria.User_Controls.AnimatedWrapPanel  -   5           Name$  awpArtworks��5d   (   
�������6=   5e      �� 5f      -   5        $ 
sellButton��5f      $��Right=�61   $��Bottom=�6M   $��	0,0,20,20q�6h   $��Vender��6{   
��� E��
���  ��6�   5g      5h      �� 5i      -   5        $
 Pst2��5i      ��5j      �� 5k      -   5         
 CGpst2#���  5k      #��[ 6]   .��5m      � .+�5n      � -   5        ! �Name$! closedServer��5n      
������$ 25��6I   $y�Visible=�6[   .+�5o      �� -   5        $ 
tryConnect��5o   !     
tryConnect#���  65   6\   5p      �� 5r      -   5        $ lblObra��5r      $��	(título)��6-   $
��Left=�6@   $��10,5,0,0q�6[   $	��Top=�6m   �� 5s      
���   �$��1q�61   $��Stretch=�6E   $��10,30,300,37q�6c   $��Stretch=�6y   ._�5t      �� -   5        " ��Name$" image��5t       5u      �� 5w      -   5        # ��Name$# 
borderPuja��5w      
���   �$��1q�6E   $
��Left=�6Y   $��90��6t   $��	13,0,0,40q�6�   $��Bottom=�6�   $	��200��6�   ._�5x      �� .+�5y      �� -   5        $" imgPuja��5y   $     minimize#��[ 65   $ 5��6X   $ �� Right$$ 0��6i   
% �� Top$% 0��6z   $��10��6�   & � Cursor$
& Hand��6�   6�   �� 5z      -   5        $ txtPuja��5z   &   ' �� TextAlignment$' Right=�67   $��33��6M   $ 4��6Y   ( �� Left$( 10��6j   ) �� TextWrapping$
) Wrap=�6{   $	��177��6�   $ Cantidad��6�    . 6  �� 5{      -   5        $ buttPuja��5{   %    
 CG2Bid#���  67   $( 10��6Z   $ 4��6k   $% 46��6|   $	��177��6�   6�   5|      5}      �� 5      -   5        $ label4��5        CG2Hist#���  6,   $��Right=�6P   $��	0,5,240,0q�6l   $	��Top=�6   �� 5�      
���   �$��1q�61   $��Right=�6E   $��
0,30,10,37q�6a   $��Stretch=�6u   $	��289��6�   ._�5�      �� -   5        $ scrollViewer��5�   '   .��5�      �� -   5        $ spHist��5�   )   $ Vertical=�69   5�      5�      �� 5�      $��Stretch=�6    $��37��6>   $��0,0,0,0q�6J   $��Bottom=�6[   .@�5�      �� -   5        $ 	lblEstado��5�        
 CG2Not#���  63   5�      5�      5�      �� 5�      -   5        $
 Pst3��5�      ��5�      �� 5�      -   5         
 CGpst3#���  5�      #��[ 6]   .��5�      � 
���\\��.+�5�      �� 
���   �$��1q�67   $
��Left=�6K   $	��299��6f   $��Stretch=�6r   $��
10,10,0,10q�6�   .��5�      ]� ��. .+�5�      3  -Galeria.User_Controls.Messages_Window.AddChat  -   5        *  Name$* addChat��5�   1   $��80��6B   $��3,3,0,0q�6N   $	��Top=�6_   �� 5�      -   5        $ spChat��5�   )   $ Vertical=�69   $
��Auto=�6P   
�������6�   5�      5�      4  .Galeria.User_Controls.Messages_Window.ChatView  5�      -   5        +  Name$+ chatView��5�   *   $��Stretch=�6<   $��Stretch=�6Z   $��311,10,10,10q�6v   5�      5�      �� 5�      -    5        $
 Pst4��5�      ��5�      �� 5�      -!   5         
 CGpst4#���  5�      #��[ 6]   .��5�      � 
�������.+�5�      �� $ 
Horizontal=�6!   $��Stretch=�6:   $	��Top=�6X   $��	10,0,10,0q�6p   .+�5�      �� -"   5        $ 	sub_Users��5�        	 Users#���  63   #��[ 6U   $
��Left=�6v   $	��Top=�6�   $��10,0,0,0q�6�   6�   �� 5�      -#   5        $ 	sub_Trans��5�        
 Transs#���  63   #��[ 6V   $
��Left=�6w   $	��Top=�6�   $��10,0,0,0q�6�   6�   �� 5�      -$   5        $ sub_Nats��5�         Nats#���  62   #��[ 6S   $
��Left=�6t   $	��Top=�6�   $��10,0,0,0q�6�   6�   �� 5�      -%   5        $ 	sub_Auths��5�        	 Auths#���  63   #��[ 6U   $
��Left=�6v   $	��Top=�6�   $��10,0,0,0q�6�   6�   �� 5�      -&   5        $ 	sub_Types��5�        	 Types#���  63   #��[ 6U   $
��Left=�6v   $	��Top=�6�   $��10,0,0,0q�6�   6�   �� 5�      -'   5        $ sub_Arts��5�         Arts#���  62   #��[ 6S   $
��Left=�6t   $	��Top=�6�   $��10,0,0,0q�6�   6�   5�      7	  1Galeria.User_Controls.Management_Windows.MngUsers	  5�      -(   5        , 	 Name$, 	gridUsers��5�   2   $��Stretch=�6E   $��Stretch=�6c   $y�Hidden=�6   $��0,35,0,0q�6�   7
  1Galeria.User_Controls.Management_Windows.MngTrans
  5�      -)   5        - 
 Name$- 	gridTrans��5�   2   $��Stretch=�6E   $��Stretch=�6c   $y�Hidden=�6   $��0,35,0,0q�6�   6  0Galeria.User_Controls.Management_Windows.MngNats  5�      -*   5        .  Name$. gridNats��5�   1   $��Stretch=�6C   $��Stretch=�6a   $y�Hidden=�6}   $��0,35,0,0q�6�   7  1Galeria.User_Controls.Management_Windows.MngAuths  5�      -+   5        /  Name$/ 	gridAuths��5�   2   $��Stretch=�6E   $��Stretch=�6c   $y�Hidden=�6   $��0,35,0,0q�6�   7  1Galeria.User_Controls.Management_Windows.MngTypes  5�      -,   5        0  Name$0 	gridTypes��5�   2   $��Stretch=�6E   $��Stretch=�6c   $y�Hidden=�6   $��0,35,0,0q�6�   6  0Galeria.User_Controls.Management_Windows.MngArts  5�      --   5        1  Name$1 gridArts��5�   1   $��Stretch=�6C   $��Stretch=�6a   $y�Hidden=�6}   $��0,35,0,0q�6�   5�      5�      5�      �� 5�   
   -.   5        $ spPerfil��5�      $ 
Horizontal=�6'   $��1��6@   
������$��Right=�6i   $	��230��6�   .+�5�      ,  &Galeria.User_Controls.LanguageSelector  -/   5        2  Name$2 languageSelector��5�   -   $
��Left=�6G   $	��Top=�6b   �� 5�      -0   5        $ 
userButton��5�      $
��Left=�6)   $��0,0,0,0q�6D   $	��Top=�6U   $	��100��6m   $��36��6y   $��2q�6�   
����·����	#FF70C8FF#��[ 6�   .��5�      (� .��5�      �� -1   5        3 ��Name$3 tbNick��5�       $
��nick��60   4 J� IsHitTestVisible4 .  
���   �6U   5�      5�      5�      � 5�   
   -2   5        $! shadow��5�      $y�Hidden=�6   $ 50��63   $��Stretch=�6E   $��Stretch=�6a   $��2��6   ��5�      �� 5�      5 �� EndPoint$5 0.5,1&�6&   6 �� 
StartPoint$6 0.5,0&�67   7 �� Opacity$
7 0.85Q�6J   .��5�      � 8 � Color$8 Black��6#   9 � Offset$9 0Q�61   � 5�      $8 	#FF7A7171��6#   $9 1Q�65   5�      5�      � 5�   
   -3   5        $
! show��5�      $y�Visible=�6   $ 75��62   $��Stretch=�6D   $��Stretch=�6`   $��2��6~   � 5�   
   -4   5        $! overAllShadow��5�      $y�Hidden=�6&   $	 100��6:   $��Stretch=�6M   $��Stretch=�6i   $��2��6�   ��5�      �� 5�      $5 0.5,0&�6&   $6 0.5,1&�67   $
7 0.85Q�6J   .��5�      � $8 Black��6#   $9 1Q�61   � 5�      $8 	#FF7A7171��6#   $9 0Q�65   5�      5�      5�      5�      
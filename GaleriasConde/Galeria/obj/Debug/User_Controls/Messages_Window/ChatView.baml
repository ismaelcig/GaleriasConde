   M S B A M L   `   `   `  ����B  >Galeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:Galeria.User_Controls.Messages_Window%Galeria.User_Controls.Messages_Window  5      4    .Galeria.User_Controls.Messages_Window.ChatView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:Galeria.User_Controls.Messages_Window     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 	Resources  5
       �� 
TargetType   NameTag �� Property �� Value  MsgStyle��%�  &	        &	 �     �� 5   
   " ��6   .�5      ��  � ��
 � � �6+   �� 5       � ��$ 5q�6'   �� 5       � ��$ 12(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 5q�6'   �� 5       � ��$
 Wrap=�6-   �� 5       � ��$ 15(�6)   �� 5       � ��$ SemiBold"�6+   5      5      .��5      � 
�������.+�5   
   ]� $��Stretch=�6   $	��Top=�62   $	��100��6J   
�������.+�5      A� $
��Left=�6   $
��Left=�6,   $��99��6G   
���   �$	��Top=�6b   $��99��6z   ��5      �� 5      -   5        img��5   !   5      �� 5       -   5         ��Name$ chatName��5       $	��Top=�6&   $�� ��6;   $��25(�6F   $��Expanded&�6T   $��Black"�6k   $
��Left=�6~   $��	10,10,0,0q�6�   $	��Top=�6�   �� 5!      -   5        $ 	chatUsers��5!      $�� ��6'   $��Italic$�62   $
��Left=�6E   $��10,0,0,0q�6`   $	��Top=�6r   5"      �� 5#   
   
���   �$��0,1,0,1q�6%   $��Stretch=�6?   $��Stretch=�6[   $��
0,100,0,50q�6y   ._�5$      �� .��5%      �� -   5         ��Name$ spMsgs��5%       �� Orientation$ Vertical=�6-   $��Visible=�6D   5&      5'      ]� 5(   
   $��Stretch=�6   $��Bottom=�62   $��50��6M   
���������. .+�5)      �� -   5         ��Name$ 	adjbutton��5)       
 camera#��[ 6'    � Cursor$
 Hand��6h   $
��Left=�6v   $
��Left=�6�   $��5,0,5,0q�6�   �� 5*      -   5        $ 
sendbutton��5*        send#��[ 6(   $
 Hand��6h   $��Right=�6v   $��Right=�6�   $��5,7,5,7q�6�   �� 5+      -   5        	 ��Name$		 txt��5+      $��40��6#   
������� 	 CVtxt)  #MaterialDesignThemes.Wpf.HintAssist
   Hint#
 �  6B      FloatingScale$	 0.8Q�6{   6�   5,      � 5-   
   -   5         �Name$ shadow��5-      
������� J� Opacity$	 0.2Q�66    K� ZIndex$ 10��6D   $y�Visible=�6V   � 5.   
   -	   5        $
 edit��5.      $��Stretch=�6   $��Stretch=�6;   $y�Hidden=�6W   .+�5/      �� -
   5        $	 textBox��5/       �� 	MaxLength$ 25��6'   $
��Left=�6P   $��40��6k   $��
105,10,0,0q�6w    �� TextWrapping$
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��311��6�   50      51      52      
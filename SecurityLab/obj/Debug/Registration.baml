   M S B A M L   `   `   `  ����F  BSecurityLab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SecurityLabSecurityLab  5   	       SecurityLab.Registration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SecurityLab     5   	     � Title$  Registration��5   	   $
��1080��6   $
��1920��6,    � WindowStartupLocation$ CenterScreen=�69    � SizeToContent$ WidthAndHeight=�6^    � WindowState$ 	Maximized=�6}    � 	Resources 5	         TB �� 
TargetType �� Property �� Value �� 
TargetType	 �Name
 J� SnapsToDevicePixels ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value��%�  &	        �� 5
   
   " ��6   .�5      ��  � �� �#0000FF6+   �� 5       � ��$ Center=�69   �� 5       � ��$ 35��6'   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � �� �#1E90FF6,   �� 5       � ��$ 10,0,0,0q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      � $
	 Root��6   #��z��6-   #��z��6O   
 . .+�5      �� $ 	Backround��6%   $��1q�68   $ 2��6L   #��z��6]   #��z��6�   �� 5      $ PART_ContentHost��6+   $��0q�6E   #��z��6Y   ��.  #��z��5   +   ��5   =   Z� 5   +   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  � ��
 �����6@   5      P� 5       �@J�	IsFocused . . �5    "   ��  � �� �#0000CD6@   �� 5!   "    � �� �#00008B6?   5"      5$      5&      5'      5(      .��5)      � .+�5*   
   �� $(��"/Img/photo_2021-01-21_23-43-45.jpg��6   $
��Fill=�6<   $��
0,0,-0.4,0q�6K   �� 5+   
   $
��Bold"�6   ���	#FF2121B9$��РЕГИСТРАЦИЯ��6:   $
��Left=�6P   $��817,254,0,0q�6k   $	��Top=�6�   $��36(�6�   $��46��6�   $	��278��6�   $��Arial Unicode MS)�6�   �� 5,   
   -   5         ��Name$
 name��5,      #��[  6!   $��705,333,712,0q�6=   $	��Top=�6T   
���   �$��50��6   
����������	#FF0B24E06�   �� 5-   
    J� IsHitTestVisible .  $��14(�6-   $��Имя��6;   $��718,344,727,0q�6F   $	��Top=�6]   ���#A9A9A9$��30��6�   ��5.      �� 5/      " ��6   .�50      ��  � y�$ 	Collapsed=�63    �� Triggers 51      �� 52       �� Binding 6&   �� *Text+ �� ElementName$
 name�� �� Value  6Q   .a�53      ��  � y�$ Visible=�6;   54      56      58      �� 5:   
   -   5        $	 job��5:      #��[  6    $��705,409,712,0q�6<   $	��Top=�6S   
���   �$��50��6~   
����������	#FF0B24E06�   �� 5;   
    .  $��14(�6-   $��Должность��6;   $��718,423,727,0q�6L   $	��Top=�6c   ���#A9A9A9$��28��6�   ��5<      �� 5=      " ��6   .�5>      ��  � y�$ 	Collapsed=�63    5?      �� 5@       6&   �� *Text+$	 job��  6P   .a�5A      ��  � y�$ Visible=�6;   5B      5D      5F      �� 5G   
   -   5        $ phone��5G      #��[  6"   $��705,483,712,0q�6>   $	��Top=�6U   
���   �$��50��6�   
����������	#FF0B24E06�   �� 5H   
    .  $��14(�6-   $��№ телефона��6;   $��718,495,727,0q�6M   $	��Top=�6d   ���#A9A9A9$��27��6�   ��5I      �� 5J      " ��6   .�5K      ��  � y�$ 	Collapsed=�63    5L      �� 5M       6&   �� *Text+$ phone��  6R   .a�5N      ��  � y�$ Visible=�6;   5O      5Q      5S      �� 5T   
   -   5        $
 pass��5T      #��[  6!   $��705,557,712,0q�6=   $	��Top=�6T   
���   �$��50��6   
����������	#FF0B24E06�   �� 5U   
    .  $��14(�6-   $��Пароль��6;   $��718,568,727,0q�6I   $	��Top=�6`   ���#A9A9A9$��27��6�   ��5V      �� 5W      " ��6   .�5X      ��  � y�$ 	Collapsed=�63    5Y      �� 5Z       6&   �� *Text+$
 pass��  6Q   .a�5[      ��  � y�$ Visible=�6;   5\      5^      5`      �� 5a   
   -   5        $ pass2��5a      #��[  6"   $��705,630,712,0q�6>   $	��Top=�6U   
���   �$��50��6�   
����������	#FF0B24E06�   �� 5b   
    .  $��14(�6-   $%��Повторите пароль��6;   $��718,639,727,0q�6S   $	��Top=�6j   ���#A9A9A9$��30��6�   ��5c      �� 5d      " ��6   .�5e      ��  � y�$ 	Collapsed=�63    5f      �� 5g       6&   �� *Text+$ pass2��  6R   .a�5h      ��  � y�$ Visible=�6;   5i      5k      5m      �� 5o   
   -   5        $��	butBorder��5o      $��705,718,712,239q�6"   $��1q�5p   	   
������ ��5q      �� 5r      " ��6   .�5s      ��  � ��
 ���� 64   5t      ._�5v      �� -   5        $��Выполнить��5v      $��16(�6)   
�������$��0.2,0.2,-1,0q�6J   ��5w      �� 5x      " ��6   .�5y      ��  �@�OverridesDefaultStyle . 6B   �� 5z       � �� �#0000CD67   �� 5{       � �� 5|      �� 5}   "   " ��62   .R�5~   &   �� $��border��6-   $��0q�6;   
���   �#��z��5   )   ._�5�   *   �� $��Center=�6;   $��Center=�6X   5�   '    5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � �� �#0000FF6K   5�   +   :� 5�   *    :� RoutedEvent$ PreviewMouseDown��67   .[�5�   .   �� .��5�   2   �� .��5�   6   t�  �� TargetProperty$ Margin�6I    g� Duration$ 	0:0:0.100D�5�   E   	 t� To$ 2,2,0,0X�6Z   �� 5�   6   $ Background.Color�6E   	 �� To$ #000080X�6r   $ 	0:0:0.002D�6   5�   3   5�   /   5�   +   :� 5�   *   $ PreviewMouseUp��67   .[�5�   .   �� .��5�   2   �� .��5�   6   t� $ Margin�6I   $ 	0:0:0.100D�5�   E   $ 0X�6Z   �� 5�   6   $ Background.Color�6E   $ #0000CDX�6r   $ 	0:0:0.002D�6   5�   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      �� 5�   
   $��securitylab��6   $
��Left=�6&   $��1112,206,0,0q�6A   $	��Top=�6W   ���	#FF2121B9$��20(�6�   �� 5�   
   -   5        $
��Left=�5�   ,   $��60��6G   $��695,206,0,0q�6S   $	��Top=�6h   $��60��6�   $0��*Img/iconfinder_undo-back-arrow_2931166.png��6�   5�      5�      
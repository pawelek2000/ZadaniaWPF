   M S B A M L   `   `   `  ����B  >WpfMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfMVVMWpfMVVM  5   	   ?$clr-namespace:WpfMVVM.MVVM.ViewModelWpfMVVM.MVVM.ViewModel  5   	       WpfMVVM.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfMVVM     5   	   :	viewModel$clr-namespace:WpfMVVM.MVVM.ViewModel     5   	     � Title$  Negocjacyjny program��5	   	   $	��450��6&   $	��800��66   $	��450��5
   	   $	��800��6    � DataContext 5      *  $WpfMVVM.MVVM.ViewModel.MainViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� 
���   �$��0,0,1,0q�5      ._�5      �  � RowDefinitions 5      �� 5      $��40 �6$   �� 5      �� 5      $��40 �6$   .+�5      �� 
����� �$��Dodaj nową kwestie��5      $	��130��5       $��30��5!      $
��10,0q�5"      $��0q�5#      $
��Left=�5$      ��5%      �� *NowaKwestiaCommand+��5&      �� 5(      �� 5*      
����� �$��Stworz Opcje��5+      $��3��5,      $	��130��5-      $��30��5.      $
��10,0q�5/      $��0q�50      $��Right=�51      ��52      �� *BartoszCommand+54      �� 56      $��1��6   
���   �$
��0,20q�58      $	��0,1q�59      ._�5:      �� -   5        $��ScrollContainer��5:   #   $��Hidden=�5<   #   $��Hidden=�5=   #   .��5>      �� -   5         ��Name$ listBox��5>      $��Hidden=�5?      $��Hidden=�5@      ��.  
������ ��5B      �� *ListaKwestii+ �� SelectedItem 5C      �� *WybranaKwestia+��5E      �� 5F   "    �� 
TargetType" ��6(   .�5G   &   ��  �� Property �@��
IsSelected �� Value 6C   �� *Content.IsSelected+	 �� Mode$	 TwoWay=�
 �� RelativeSource
 �� *Self+�� 5H   &    � �� 5I   *   �� 5J   .    �� 
TargetType" ��6>   .R�5K   2   �� 5L   /   5N   '   5O   #   ��5R      �� 5S      .R�5T   "   �  5U   &   �� 5V   *   $��40 �68   �� 5W   *   .+�5Y   &   �  5Z   *   �� 5[   .   �� 5\   .   $��20 �6?   �� 5]   .   $��20 �6?   .+�5_   *   ��  �� ContentStringFormat$
 #{0}��5`   0   $��5q�5a   0   $��16(�5b   0   $��DemiBold"�5c   0   ��5_   0   �� *Nazwa+5e   +   �� 5g   .   $��1��65   
������ $��0q�5i   1   ��5j   1   ��  �� ElementName$ listBox�� �� Path$+ %DataContext.NowyElementKwestiiCommand���5k   1   �� .��5l   2   �� $��/Images/add_icon.png��68   $��20��5m   4   $��20��6?    �� BitmapScalingMode$
 Fant=�5n   4   5o   /   �� 5q   .   $��2��65   
������ $��0q�5s   1   ��5t   1   �� $ listBox��$ DataContext.OtworzCommand���5u   1   �� .��5v   .   �� $"��/Images/expand_more_icon.png��64   $��20��5w   4   $��20��6?   $
 Fant=�5x   4   5y   +   5z   '   � 5{   &   $��1��6+   
������ y�5|   +   �� *
IsOpened+.+�5~   *   �� $ listBoxSrodkowy��62   $��Hidden=�5   2   $��Hidden=�5�   2   ��.  
������ 
������ $��10,0,0,0q�5�   2   ��5�   2   �� *ElementyKwestii+��5�   2   �� 5�   6   " ��6<   .�5�   :   ��  �@��
IsSelected 6W   �� *Content.IsSelected+$	 TwoWay=�
 �� *Self+�� 5�   :    � �� 5�   >   �� 5�   B   " ��6R   .R�5�   F   �� 5�   C   5�   ;   5�   7   ��5�   2   �� 5�   2   .R�5�   6   �  5�   :   �� 5�   >   $��40 �6L   �� 5�   >   .+�5�   :   ��  �� Orientation$ 
Horizontal=�6E   .+�5�   @   �� $��5q�5�   F   $��14(�5�   F   $��Italic$�5�   F   ��5�   F   �� *Opcja+5�   A   �� 5�   @   $��5q�5�   F   $��14(�5�   F   $��Italic$�5�   F   $��20,0,0,0q�5�   F   $��Right=�5�   F   ��5�   F   �� *Ocena+5�   A   5�   ;   5�   7   5�   3   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      
   M S B A M L   `   `   `  ����C  ?Practoz5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Practoz5Practoz5  5          Practoz5.Products   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Practoz5     5      -   5          N� Title$  Products��5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��60��6   $��60��6+   �� 5      $��60��6   $��60��6+    � ColumnDefinitions 5   
   �� 5      $��95��6   $��95��6-   �� 5      $��95��6   $��95��6-   �� 5      $��95��6   $��95��6-   �� 5      $��95��6   $��95��6-   �� 5      $��95��6   $��95��6-   �� 5      $��95��6   $��95��6-   �� 5      �� 5       .+�5"   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ProductTable��5"      $��	10,10,0,0q�6)   $��8��6<   $��5��6P   $	��246��6a   $	��Top=�6n   $
��Left=�6�   $	��780��6�   �� 5#   
   -   5         ��Name$ DeleteClick��5#      ���	#FF679B9B$��3q�6=   ���	#FFFF9A76+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 12��6i   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp8=�6�   $��2��6�   $��7��6�   $��40��6�   $��Center=�6�   $��Center=�6
  $��74��6'  .��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�6&   $��34��64   $��48��6@   $��Center=�6K   ���	#FFFFEADB6h   5%      �� 5&   
   -   5        $ AddClick��5&      ���	#FF679B9B$��3q�6:   ���	#FFFF9A76$ 12��6f   $	 Dp8=�6�   $��1��6�   $��7��6�   $��40��6�   $��Center=�6�   $��Center=�6  $��75��6$  .��5'        $ AccountPlus=�6&   ���	#FFFFEADB$��32��6P   $��33��6\   $��Center=�6g   5(      �� 5)   
   -   5        $ ChangeClick��5)      ���	#FF679B9B$��3q�6=   ���	#FFFF9A76$ 12��6i   $	 Dp8=�6�   $��7��6�   $��40��6�   $��Center=�6�   $��Center=�6�   $��75��6  .��5*        $ FileArrowLeftRightOutline=�6&   ���	#FFFFEADB$��32��6^   $��33��6j   $��Center=�6u   5+      �� 5,   
   -   5         ��Name$ Price��5,      	 �� 	MaxLength$	 15��5-      $��2q�5.      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Цена��5/       !  MaterialDesignOutlinedTextBox#��[  50      $��2��6:   $��3��6N   $��7��6^   ���	#FFFF9A76$
��Bold"�6�   ���	#FF679B9B �� 
CaretBrush �	#FF679B9B �� SelectionBrush �	#FF679B9B$��50��6�   $��Center=�6   $
��Left=�6  $	��186��66  $��1,0,0,0q�6B  ��6k   Z� 6B  �� 51   
   -   5        $ ID��51      $��2q�52      $
 ID��53         
HelperText$ Введите ID��54      #��[  55      $��3��6<   $��6��6L   ���	#FFFF9A76���	#FF679B9B �	#FF679B9B �	#FF679B9B �� TextAlignment$ Center=�6�   $��50��6�   $	��Top=�6�   $��Center=�6  $��94��6(  $
��Bold"�63  ��6Y   Z� 63  �� 56   
   -   5         ��Name$ 
StorageCBX��56      $��2q�57      $
 Ячейка��58       " MaterialDesignOutlinedComboBox#��[ 59      $��4��69   $��3��6I   $��20,0,0,8q�6]   $��6��6o   ���	#FF679B9B���	#FFFF9A76$��Bottom=�6�   $
��Left=�6�   $	��190��6�   $
��Bold"�6�   �� 5:   
   -	   5        $ 
CotegorCBX��5:      $��2q�5;      $
 Категория��5<      #��[ 5=      $��5��69   $��2��6I   $��10,0,0,0q�6]   $��7��6o   ���	#FF679B9B���	#FFFF9A76$
��Left=�6�   $	��190��6�   $
��Bold"�6�   �� 5>   
   -
   5        $ 
ReviewsCBX��5>      $��2q�5?      $
 
Отзов��5@      #��[ 5A      $��6��69   $��2��6I   $��30,0,0,8q�6]   $��6��6o   ���	#FF679B9B���	#FFFF9A76$��Bottom=�6�   $
��Left=�6�   $	��190��6�   $
��Bold"�6�   5B      5C      
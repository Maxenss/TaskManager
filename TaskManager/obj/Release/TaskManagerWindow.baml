   M S B A M L   `   `   `  ���� F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  #    TaskManager.TaskManagerWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:TaskManager       � Title$#  Диспетчер задач��$	��600��$	��610�� � 
ResizeMode$ NoResize=� � Icon$A ;C:\Backup\repos\TaskManager\TaskManager\taskmanagerlogo.png��.��� .+��� $
��Left=�$	��543��$	��Top=�$	��580��$��	10,10,0,0q�.@��� $��Очередь��.��� ���	#FFE5E5E5.+�&   System.Windows.Controls.DataGrid  -   $��dgProcessList��   
IsReadOnly . $
��Left=�   AutoGenerateColumns .  $	��Top=�$	��470��$	��575��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   CanUserResize .     CanUserReorder .  	   CanUserSort	 .  
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 40 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� -   $ ��labelProcessesInQueueCount��$,��&Процессов в очереди: ��$
��Left=�$��372,470,0,-1q�$	��Top=��� $��Отклоненные��.��� ���	#FFE5E5E5.+�  -   $��dgCanceledProcessList�� . $
��Left=� .  $	��Top=�$	��470��$	��575��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 90  �� $ Priority�  $ Статус�� .   .  	 .  $
 95  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� -   $ ��labelProcssesCanceledCount��$1��+Отклоненных процессов: ��$
��Left=�$��372,470,0,-1q�$	��Top=��� $��Выполненные��.��� ���	#FFE5E5E5.+�  -   $��dgCompletedProcessList�� . $
��Left=� .  $	��Top=�$	��470��$	��575��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate�  $ Выполнен�� .   .  	 .  $	
 150  �� $ TimeOfCompleted��� -   $"��labelProcessesCompletedCount��$1��+Выполненных процессов: ��$
��Left=�$��372,470,0,-1q�$	��Top=��� $.��(В процессе выполнения��.��� ���	#FFE5E5E5.+�  -   $��dgExecuteProcessList�� . $
��Left=� .  $	��Top=�$	��515��$	��575��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� $��Ресурс 1��.��� ���	#FFE5E5E5.+��� $
��Left=�$	��495��$��-1,0,0,0q�$	��Top=�$	��575��.@��� $��Очередь��.��� ���	#FFE5E5E5$��10,2,4,4q�.+�  -   $!��dgResourceQueue1ProcessList�� . $
��Left=� .  $	��Top=�$	��461��$	��555��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� $��Выполнение��.��� ���	#FFE5E5E5$��10,2,4,4q�.+�  -	   $��dgResource1ProcessList�� . $
��Left=� .  $	��Top=�$	��461��$	��555��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� $��Ресурс 2��.��� ���	#FFE5E5E5.+��� $
��Left=�$	��495��$��-1,0,0,0q�$	��Top=�$	��575��.@��� $��Очередь��.��� ���	#FFE5E5E5$��10,2,4,4q�.+�  -
   $!��dgResourceQueue2ProcessList�� . $
��Left=� .  $	��Top=�$	��461��$	��555��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� $��Выполнение��.��� ���	#FFE5E5E5$��10,2,4,4q�.+�  -   $��dgResource2ProcessList�� . $
��Left=� .  $	��Top=�$	��461��$	��555��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� $��Ресурс 3��.��� ���	#FFE5E5E5.+��� $
��Left=�$	��495��$��-1,0,0,0q�$	��Top=�$	��575��.@��� $��Очередь��.��� ���	#FFE5E5E5$��10,2,4,4q�.+�  -   $!��dgResourceQueue3ProcessList�� . $
��Left=� .  $	��Top=�$	��461��$	��555��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� $��Выполнение��.��� ���	#FFE5E5E5$��10,2,4,4q�.+�  -   $��dgResource3ProcessList�� . $
��Left=� .  $	��Top=�$	��461��$	��555��   $ ID�� .   .  	 .  $
 40  �� $ Id�  $ Имя�� .   .  	 .  $
 90  �� $
 Name�  $ Приоритет�� .   .  	 .  $
 95  �� $ Priority�  $ Статус�� .   .  	 .  $
 90  �� $ StatusString�  $	 RAM�� .   .  	 .  $
 50  �� $	 RAM�  $ 
Такты�� .   .  	 .  $
 50  �� $ CountOfTactsAll�  $% Время добавления�� .   .  	 .  $	
 150  �� $ TimeOfCreate��� $��Сервис��.��� ���	#FFE5E5E5.+��� -   $��btGenerateTProcess��$8��2Сгенерировать один процесс��$
��Left=�$��
177,52,0,0q�$	��Top=�$	��209���� -    ��Name$ btGenerate10TProcess��$@��:Сгенерировать десять процессов��$
��Left=�$��
177,90,0,0q�$	��Top=�$	��209���� -   $ btGenerate100TProcess��$:��4Сгенерировать сто процессов��$
��Left=�$��177,129,0,0q�$	��Top=�$	��209���� $2��,Сведения об устройстве: ��$
��Left=�$��209,176,0,0q�$	��Top=��� -    ��Name$ labelCountRAM��$+��%Общее количество RAM: ��$
��Left=�$��177,207,0,0q�$	��Top=��� -   $ labelCountRAMFree��$3��-Свободное количество RAM: ��$
��Left=�$��177,233,0,0q�$	��Top=��� -   $ labelCountRAMUsed��$$��Использовано RAM: ��$
��Left=�$��177,259,0,0q�$	��Top=��� -   $ labelCPUFreq��$+��%Частота процессора: ��$
��Left=�$��177,285,0,0q�$	��Top=��� -   $ btSetConfig��$/��)Изменить конфигурацию��$
��Left=�$��177,331,0,0q�$	��Top=�$	��209���� -   $��labelDelayCompleted��$=��7Среднее время для выполнения: ��$
��Left=�$��
45,378,0,0q�$	��Top=��� -   $ labelDelayToStart��$J��DСреднее время для начала выполнения: ��$
��Left=�$��
45,409,0,0q�$	��Top=��� $2��,Сведения об устройстве: ��$
��Left=�$��209,176,0,0q�$	��Top=�
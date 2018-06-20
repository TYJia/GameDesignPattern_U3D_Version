# 命令模式

## 使用说明
* 运行后，WASD控制方块运动，场景中Manager勾选掉IsRun，可以实现时光回流的效果。

## 类说明

### Command
* 抽象基类，包含了时间戳和运行、回退的虚方法

### CommandMove
* Command的子类，可以调用指定Avatar的Move函数

### Avatar
* 执行行为的目标物体，拥有Move函数

### CommandManager
* 当IsRun为true时，由WASD按键生成命令对象，执行Execute(Avatar)
* 当IsRun为false时，调用RunCallBack()，按时间将栈内命令提取出并执行Undo(Avatar)
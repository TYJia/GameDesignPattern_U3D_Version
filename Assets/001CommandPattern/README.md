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

-----

## [笔记](https://gpp.tkchu.me/command.html)

### 是什么（个人理解）

将命令封装，与目标行为解耦，使命令由流程概念变为对象数据

### 为什么

既然命令变成了数据，就是可以被传递、存储、重复利用的：

- 通过命令数据队列或栈可以轻易实现撤销、重做、时光倒流
- 命令数据还可以形成日志，用于复现用户行为，便于重复测试同样序列命令对各种目标的影响
- 这些命令数据可以发送给不同的目标，比如同样的“出发，5分钟后，停止”，发送给飞机就可以变成“起飞，5分钟后，降落”，发送给轮船就成了“离港，5分钟后，抛锚”

### 怎么做（U3D示例）

类图如下：
![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/001CommandPattern/UML/001CommandPattern.png)

具体实现：[](https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/001CommandPattern)https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/001CommandPattern 

### 缺陷

可能会导致大量的实例化，从而浪费内存

### 拓展

可用享元模式代替大量的实例化

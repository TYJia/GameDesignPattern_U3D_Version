# 状态模式

## 项目说明

这个场景内有两个状态机：

- 一个是Switch Case实现的冷暖光，运行后点击“Switch”按键即可观察
- 一个是State Class实现的交通灯，运行后会自动变换

---

## [笔记](https://gpp.tkchu.me/state.html)

### 是什么（个人理解）

现在状态和条件决定对象的新状态，状态决定行为（Unity内AnimationController就是状态机）

### 为什么

- 使流程清晰化、结构化
- 简化判断逻辑，比如嘴的状态是洗牙，那就不应该做出咀嚼的行为；必须是在憋气，那就不应该做出呼吸的行为

### 注解

- 状态机（自动机）是我最喜欢的一种设计模式，因为这样设计的程序逻辑清晰，稳定性也很强
- 作者对switch case下的状态机理解并不深刻，一般情况下，状态机需要两个switch case，一个用于处理状态变化，另一个用来处理状态行为
- 相比状态类，个人更喜欢switch case的方法，虽然状态类有其有点，但缺点也非常明显——当状态量较大时，代码量激增，可读性也很差，状态变化和状态行为都需要大量的信息传递，十分不便

### 怎么做

这次我实现了两个版本：

1. SwitchCase版本，用按键控制一盏冷暖灯，关灯状态下，按一次打开暖光，再按切换为白光，再按变为暖白光，再按关闭
2. 状态类版本，交通灯 停止、通行、闪烁、等待的切换

另外自动机用类图描述不是好方法，应该用自动机专门的图来说明才对

#### SwitchCase版本类图及自动机如下：

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/006StatePattern/UML/006StatePattern-SwitchCase.png)

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/006StatePattern/UML/LightSwitchCase.png)

#### StateClass版本类图及自动机如下：

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/006StatePattern/UML/006StatePattern-StateClass.png)

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/006StatePattern/UML/LightStateClass.png)

#### 具体实现：

https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/006StatePattern
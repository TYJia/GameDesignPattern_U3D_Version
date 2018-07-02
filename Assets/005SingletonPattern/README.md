# 单例模式

## 项目说明

### TimeLogger

用于生成日志，使用了单例模式

### Speaker

在场景中有多个实例，讲话时会调用TimeLogger单例

### Log.txt

TimeLogger生成的日志

---

## [笔记](https://gpp.tkchu.me/singleton.html)

### 是什么（个人理解）

使用单例意味着这个对象只有一个实例，这个实例是此对象自行构造的，并且可向全局提供

### 为什么

- 减少代码复用，让专门的类处理专门的事情——例如让TimeLog类来记录日志，而不是把StreamWriter的代码写到每一个类里
- 快速访问，任何其他类都可以通过ClassName.Instance来访问单例，使用它的公开变量和方法

### 缺陷

- 因为实现简单，而且使用方便，所以有被滥用的趋势
- 滥用单例会促进耦合的发生，因为单例是全局可访问的，如果不该访问者访问了单例，就会造成过耦合——例如如果播放器允许单例，那石头碰撞地面后就可以直接调用播放器来播放声音，这在程序世界并不合理，而且会破坏架构
- 如果很多很多类和对象调用了某个单例并做了一系列修改，那想理解具体发生了什么就困难了
- 对多线程不太友好——每个线程都可以访问这个单例，会产生初始化、死锁等一系列问题

### 怎么做

U3D中利用MonoBehaviour初始化单例非常简单，只要在Awake中加入Instance = this，不过要注意的是，别的类不能在Awake里使用这个单例

单例在普通C#中还有其他做法，甚至有些泛型、线程安全的扩展，也都不复杂，可以自行查询

#### 类图如下：

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/005SingletonPattern/UML/005SingletonPattern.png)

#### 具体实现：

https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/005SingletonPattern
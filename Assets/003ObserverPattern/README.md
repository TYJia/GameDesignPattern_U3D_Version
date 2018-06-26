# 观察者模式

## 项目说明

### Emitter

通过EmitBall()方法释放气球（白色球体），并通知Radio有释放气球的事件（调用 OnEmitEvent (Transform target) ）

### Shooter

告诉Radio要收听（观察）OnEmitEvent事件，事件发生时向气球射击，发出红色子弹

---

## [笔记](https://gpp.tkchu.me/observer.html)

### 是什么（个人理解）

事件与其他对象行为的解耦——例如一个代码描述了日本核电站爆炸的事件，世界人民买盐这种行为显然不应该由核电站爆炸直接调用，而是通过卫星电视告诉广大群众，群众想买盐还是想买仙人掌就由他们自己决定了~

### 为什么

- 解耦，物价局改了粮价不需要挨家挨户通知公民，只需要让电视台播个新闻就好
  - 如果要挨家挨户通知，物价局必须有每个公民的地址，这显然不合理，也会浪费很多资源
  - 扩展困难——如果公民改了地址或者有新公民出生了，那还需要告诉物价局，这也很荒唐

### 怎么做

#### 类图如下：

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/003ObserverPattern/UML/003ObserverPattern.png)

射手（Shooter，观察者，这里是听众）告诉广播电台（Radio）自己要听发射气球的广播

吹气球的人（Emitter） 向上发出气球，并告诉广播电台自己发射了气球

广播电台广播发射了气球的消息，所有射手向气球射击

这个例子中吹气球的人不会关心谁是射手，射手也不用在意谁是吹气球的人

#### 具体实现：

https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/003ObserverPattern

### 拓展

可与对象池联动，进一步减少内存的开销
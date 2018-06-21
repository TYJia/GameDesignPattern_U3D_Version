# 享元模式

## 项目说明

为说明享元模式的意义，此示例展示了开启和关闭Unity内GPU Instancing机制的效率差别

另外要特别指出的是，至少Unity内GPU  Instancing机制已经做得很好了，为了演示差别，我强制造就了一种无法合并(Batch)的状态

## 使用说明

- 运行后，每帧重新生成1000个立方体，通过勾选/取消Manager中的 IsFlyweight 来控制是否使用享元模式

## 对比

### Stats对比

未开启享元模式：

- FPS：17.6
- Batches（Draw Call 相关）：1003

![1529496951892](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/002FlyweightPattern/ReadmePic/1529496951892.png)

开启享元模式：

- FPS：71.4
- Batches（Draw Call 相关）：5

![1529496533688](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/002FlyweightPattern/ReadmePic/1529496533688.png)

### Profiler对比

![1529497451350](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/002FlyweightPattern/ReadmePic/1529497451350.png)

上图中左半部分为开启享元模式的统计，右图为未开启的统计，可以看出未开启时，CPU的压力大幅上升，而且内存使用也会随实例化而持续增加——因为垃圾回收速度远低于垃圾产生速度

所以享元模式使计算的时间和占用的空间都获得了优化

---

## [笔记](https://gpp.tkchu.me/flyweight.html)

### 是什么（个人理解）

不同的实例共享相同的特性（共性），同时保留自己的特性部分

### 为什么

- 传递的信息享元化，可以节约计算时间
- 存储的信息享元化，可以节约占用的空间
- 所以享元模式可以减少时间与空间上的代价

### 怎么做

#### 类图如下：

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/002FlyweightPattern/UML/002FlyweightPattern.png)

左半部分为享元模式下，只有一个CubeBase，通过ObjInstancing(int num)讲共享的网格、材质及一个Transform信息表传递给GPU，只有一个Draw Call，所以效率极高

右半部分为关闭享元模式后的做法，每生成一个Cube都会重新实例化一个立方体，并向GPU发送一次网格、材质和位置信息，所以1000个立方体就需要1000个Draw Call，效率极低

#### 具体实现：

https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/002FlyweightPattern

### 拓展

可与对象池联动，进一步减少内存的开销
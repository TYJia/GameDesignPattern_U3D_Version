# 原型模式

## 项目说明

### Dragon

配置在Prefab里，当克隆体被生成后，通过读取Dragons.txt内配置生成不同类型的火龙

### Spawner

生成器，每隔一段时间生成一个指定的Prefab

### Dragons.txt

用以记录不同类型的火龙配置——如胖火龙、高火龙、巨火龙、小火龙和他们各自的尺寸

> 这里为了快速实现使用txt记录配置表（我在偷懒），但实际项目里，往往使用SQL、Json、csv等方式进行配置

---

## [笔记](https://gpp.tkchu.me/observer.html)

### 是什么（个人理解）

将一个或多个对象当做原型，通过统一的生成器克隆出很多类似原型的对象，同时可以通过配置表更改克隆体属性，制造出很多具有自身个性的对象。

### 为什么

- 复用生成器，而非针对每一个不同的对象做一个生成器
- 与享元模式结合，通过配置表来实现对象的个性，将不同配置与代码解耦

### 怎么做

#### 类图如下：

![](https://github.com/TYJia/GameDesignPattern_U3D_Version/blob/master/Assets/004PrototypePattern/UML/004PrototypePattern.png)

- Unity中Prefab本质就是此模式里的原型，而Spawner要做的只是调用Instantiate方法
- 新的Prefab被生成以后，通过读取Dragons.txt里配置的信息来设置克隆体的名称和尺寸

> 注：这里为了快速实现使用txt记录配置表（我在偷懒），但实际项目里，往往使用SQL、Json、csv等方式进行配置

#### 具体实现：

https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/004PrototypePattern
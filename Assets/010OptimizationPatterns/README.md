# 优化模式

## 项目说明

Game模式下，点击鼠标可以设置多个目标点，Player（方块）会依次移向目标点；
- 层级列表中会显示对象池中的所有目标点，若未激活列表不为空，则先使用未激活的目标点
- 若未激活列表为空，则实例化目标点并加入对象池

> 优化模式中包含了四种不同的模式，这里只实现了对象池作为参考

### ObjPool

对象池类，包含了已激活列表和未激活列表，可用方法：
- AddObj：添加对象
- GetObj：获取对象，若无法获取则返回null
- DisableObj：用以替代销毁
- RemoveObj：彻底删除单个对象
- CleanPool：清空对象池

## [笔记](https://gpp.tkchu.me/decoupling-patterns.html)

### 是什么、为什么（个人理解）

包含了

- 数据局部性
  - CPU缓存读写速度大于内存读写速度，所以要尽量减少缓存不命中（CPU从内存读取信息）的次数
  - 用连续队列代替指针的不断跳转
  - 不过此模式会让代码更复杂，并伤害其灵活性
- 脏标识模式
  - 需要结果时才去执行工作——避免不必要的计算或传输开销
  - 一种是被动状态变化时才计算，否则使用缓存；另一种是主动变化标识，否则不执行（例如存盘）
- 对象池模式
  - 对象池就像一包不同颜色的水彩笔，当我们使用时就拿出来，不用时就放回去——而不是使用时就买一只，不用时就扔进垃圾桶
  - 可以减少内存碎片，减少实例化与回收对象所面临的开销

### 怎么做（对象池）

用对象池对之前实现的[例子](https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/009DecouplingPatterns)做了优化：

- 之前每次点击鼠标会生成一个目标点，Player到达目标点后会将目标点回收（Destroy）
- 优化后点击鼠标，先会尝试从对象池“未激活列表”获取对象，无法获取才会生成新对象并放入对象池中的“已激活列表”；Player到达目标点后，会把对象从已激活列表放入未激活列表，并执行SetActive(false)方法

#### 具体实现：

https://github.com/TYJia/GameDesignPattern_U3D_Version/tree/master/Assets/009DecouplingPatterns
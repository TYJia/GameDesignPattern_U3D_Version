# 序列模式

## [笔记](https://gpp.tkchu.me/state.html)

### 是什么、为什么（个人理解）

包含了

- 双缓冲模式
  - 当一个缓冲准备好后才会被使用——就像一个集装箱装满才会发货一样；当一个缓冲被使用时另一个处于准备状态，就形成了双缓冲
  - 在渲染中广泛使用，一帧准备好后才会被渲染到屏幕上——所以准备时间太长就会导致帧率下降
- 游戏循环
  - 可参考[脚本生命周期](https://docs.unity3d.com/Manual/ExecutionOrder.html)
- 更新方法
  - 同上，实际上是Unity通过反射在生命周期不同时刻调用MonoBehaviour中的相关方法

这三者一定程度上是相辅相成的，在Unity中都已在底层实现，双缓冲可以通过FrameDebugger体会，而游戏循环、更新方法则与脚本生命周期和MonoBehaviour相关
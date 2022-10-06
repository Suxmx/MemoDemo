# 操作说明  
开始界面的Start要用角色顶  
WASD上下左右移动  
J攻击  
K跳跃  
L扔手雷（目前总共能扔100个）  

# 进度报告
## 10.1 总结
以学习为主，并初步实现了一些功能

### 功能实现：
-实现了主角的移动与跳跃并且与动画机相连  
-拼装了车与炮台，添加了炮台的平衡树  
-实现了炮台的控制以及炮台角色与主角色的切换、炮台角色的方向控制  

### 遇到问题  
1.TMP在代码中getcomponent失败，以及无法改变TMP图层，有无解决方法或更好替代方案？  
2.由于炮台和角色并不是同一个动画里的 因此炮台旋转时角色会在视觉上产生偏移    Ps.10.2 0:35已解决   
3.动画机多图层怎么使用？？  


  
  
## 10.2  
-实现了炮台的开火、子弹运动与开火动画  
-添加了一个伞兵敌人  
-实现了背景的循环以模拟开车的效果  
-实现了人物的射击  
-人物受击、碰到敌人、摔到地面后会死亡  
-实现了人物的死亡后重生  



### 遇到问题  
1.代码中的物体坐标与Inspector中显示的不一样  
2.有一个人物不添加RigidBody2D则碰撞器不生效 原理未知，正确解决办法未知  
  
  好多bug  
## 10.3  
各种调bug...  
### 实现功能  
-增加了角色的下蹲以及下蹲后的碰撞体积处理  
-增加了敌人的受击死亡  
-稍微调整了炮台的动画位置使其更为自然  
-增加了一个会自己移动的直升机载具敌人  
-敌人的开火时间变成Random.Range[PerFire-2,PerFire+2]  
-制作了手雷（使用触发器好像有点bug所以用了碰撞器）  
-第一关的制作基本完成（指刷怪）  
-增加了UI（简陋版），实现了血量显示、暂停、退出功能  





### 遇到问题  
-下蹲以及转身后角色的身体与脚偏移严重....  
-在处理敌人的受击时同样遇到的不添加刚体则碰撞器不起作用的问题  
-碰撞器碰到触发器/触发器碰到碰撞器应该用OnTriggerEnter还是OnColliderEnter？  
-跳下炮台后再次上去需要矫正角色的位置  
-UI中除了拖拽还能怎么修改图层顺序  
-设置了导出分辨率但是打开时并不是设置的分辨率从而导致UI错位  

## 10.4  
### 实现功能  
-增加了分数的UI  
-完成第二关场景的制作以及人质动画制作  
-增加了人质给予的钻石等礼物  
-近战功能（制作ing）  
-大部分时间在修bug  
  
### 遇到问题  
-基本上是unity出了bug 

## 10.5  
## 实现功能   
-增加了木桶  
-增加了地雷  
-增加了生草导弹  
-增加了快乐突突突坦克  
-新增了模块化触发器 方便以摄像机上的激活器激活敌人  
-修复了一些近战攻击的bug  
-修复了一些伤害判定的bug  
-修复的人质的一些bug  
-改进了直升机  
-修复若干已知bug.jpg  

### 遇到问题  
-人质的组件被禁用后自行运行  
-Player下不同子物体的碰撞器的碰撞事件共享了  
-人麻了  
  
  ## 10.6  
  ### 实现功能   
  -增加了摩托侠  
  -增加了炮兵  
  -不知道为什么增加了已经修复好的人质的bug  
  -第二关敌人布置完成  
    
  ### 遇到问题  
  -截图发到实习群里了  TAT  
  







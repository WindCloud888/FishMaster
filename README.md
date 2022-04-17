# FishMaster
用C#与unity写的捕鱼达人游戏     
使用u3d完成了一个经典的捕鱼达人游戏，实现了基本功能，包括开始界面、游戏UI、可切换炮台、丰富的鱼类、多种绚丽的特效等    
开始界面可以选择继续游戏和新游戏，通过PlayerPrefs保存上次游戏的数据    
共有5种炮台，18种鱼，所有鱼死亡后都会掉落金币，金币会自动移动到显示钱的UI那里，其中金色鲨鱼、银色鲨鱼死亡时还有特效，此外切换炮台、升级、领取工资等均有特效，每升20级会切换场景，并且切换场景时有海浪特效    
使用了3个Canvas，一个显示背景，一个显示基本UI、鱼群、炮台等大部分游戏内容，一个显示设置面板，渲染模式均为Screen Space - Camera,以便在画布与摄像机之间实现粒子特效的效果    

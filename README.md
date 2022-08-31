# UIFramework
UI框架：MVCUIframework
基于MVC实现的UI框架部分
框架说明：
## 1、游戏入口
GameMsg.cs   运行顺序注意：先解析所有配置表，再注册所有数据，最后打开需要的面板
## 2、ConfigManager.cs
配置表管理类，所有配置表都在这里解析 你可以用它调用任意一个配置表
## 3、ModelManager.cs
管理所有数据模型，注册单个数据的方法（数据初始化）、封装对外提供的使用方法（背包数据通过该方法可调到商店数据）
## 4、UIManager.csUI管理类
包含PanelName、PanelType（fix、normal【普通打开关闭】、huchi【该面板打开normal面板关闭，打开亦然】、layer【层级面板，按顺序打开，按顺序关闭，队列实现】）
OpenUI(PanelName name)，打开面板的方法，CloseUI(PanelName name)，关闭面板的方法，UIbase LoadUIbase(PanelName name)，加载UI
## 5、UIbase、ConfigBase、Modelbase基类
## 缺点：
UI面板类型不完整，随着UI类型增多会出现大量Switch case ；

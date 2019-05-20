--部门信息
create table department(
	deptno int identity(1,1),--部门编号
	deptname nvarchar(20),--部门名称
	remark nvarchar(100),--备注
	createby nvarchar(20) not null,--创建人
	createtime datetime,--创建时间
	updateby nvarchar(20),
	updatetime datetime,
	primary key(deptno)
)

--角色信息
create table roleinfo(
	roleid int identity(1,1),--角色编号
	rolename nvarchar(15),--角色名称
	remark nvarchar(100),--备注
	createby nvarchar(20) not null,--创建人
	createtime datetime,--创建时间
	updateby nvarchar(20),
	updatetime datetime,
	primary key(roleid)
)
--菜单信息
create table menuinfo
(
	menuid int identity(1,1),--菜单编号
	menuname nvarchar(20),--菜单名称
	path nvarchar(100),--窗体路径信息
	parentid int,--父节点信息
	createby nvarchar(20) not null,--创建人
	createtime datetime,--创建时间
	updateby nvarchar(20),
	updatetime datetime,
	primary key(menuid)
)

--人员信息
CREATE TABLE dbo.sysuser(
	username nvarchar(20) NOT NULL,--用户名
	password nvarchar(30) not NULL,--密码
	realname nvarchar(10) not null,--真实姓名
	telephone nvarchar(20) not null,--联系方式
	deptno int ,--部门
	roleid int ,--角色
	createtime datetime,--创建时间
	createby nvarchar(20) not null,--创建人
	status int,--人员状态
	updateby nvarchar(20) ,--变更人，用于记录状态设置者
	primary key(username),
	foreign key (deptno) references department(deptno),
	foreign key(roleid) references roleinfo(roleid)
)
--角色对应权限
create table role_menu(
	roleid int,--角色
	menuid int,--菜单
	foreign key (roleid) references roleinfo(roleid),
	foreign key (menuid) references menuinfo(menuid)
)
--系统日志
create table operatelog(
	id int identity(1,1),
	username nvarchar(20),
	ip nvarchar(20),
	computername nvarchar(30),
	formname nvarchar(20),
	createdate datetime
)

--系统更新
create table sysversion
(
	version nvarchar(10),
	creator nvarchar(10),
	updatetime datetime,
	active bit,
	remark nvarchar(100)
)

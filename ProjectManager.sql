create table project
(
	project_no nvarchar(100) primary key,
	name nvarchar(100) not null,
	vendor nvarchar(50) not null,
	contacts nvarchar(50) not null,
	phone nvarchar(20) not null,
	start_time datetime not null,
	end_time datetime not null,
	remark nvarchar(200) 	
)

create table dept_task
(
	dept_task_no int identity(1,1) primary key,
	project_no nvarchar(100) not null foreign key references project(project_no),
	deptno int not null foreign key references department(deptno),
	username nvarchar(20) not null foreign key references sysuser(username),
	start_time datetime,
	end_time datetime,
	status int not null default 0
)

create table personal_task
(
	per_task_no int identity(1,1) primary key,
	dept_task_no int not null foreign key references dept_task(dept_task_no),
	username nvarchar(20) not null foreign key references sysuser(username),
	start_time datetime,
	end_time datetime,
	status int not null default 0
)
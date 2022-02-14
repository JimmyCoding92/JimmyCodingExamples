# ABP (ASP.NET Boilerplate) 一个价值连城的开源项目 - 基于DDD的应用开发模板
大家好，我是Jimmy，今天我想介绍一个开源项目ABP。这是一个价值连城的开源项目，我认为了解学习这个项目是能够帮助到所有的后端开发程序员。希望看到这个视频的朋友不要走开。

## ABP 背景介绍
ABP是ASP.NET boilerplate的缩写。从ABP官网的介绍我们可以看到，这个是开源的应用框架。它提供基于DDD-domain driven design的架构设计，并且应用了所有的最佳实践。这个实践包括了架构层的最佳实践，比如DDD, N-Layer, 松耦合，微服务。也包括了技术层的最佳实践，比如常见的SOLID等。这个开源项目主要针对中小型应用的二次开发。

## 为什么价值连城

### 直接运行的模板
这个项目有免费开源版本。在官网上提供了丰富的运行模板。提供了全栈项目，也包含了多种前端框架的版本，比如React，Angular，VUE。这么一个高代码质量的开源项目，我们自己如果开发一遍，按照程序员的工资，那需要多少money就不需要我多少介绍了。

### 遵循最佳实践
这个项目最具价值的部分是它遵循了所有的最佳实践。从他们的文档和代码，可以看的出，这是一个十分专业的团队开发的项目。这使得ABP可以帮助使用者快速的进行二次开发。同时里面很多最佳实践的实现，也是一份很好的学习材料。理解ABP对于我们工作的搬砖活动，都会有很大的帮助。

### 使用了业界最前沿的技术
同时这个项目使用前沿的技术。比如micro-service，容器化技术，redis，消息队列，监控集成等等。

### 提供了大量的模板
最让我感到意外的是，ABP有大量的模板可控我们参考。这可以说是ctrl c + v程序员的福音。

### 所有人都可以从中受益
综上所述，这是一个可以让所有人收益的开源项目。如果你是独立开发者，想上线一些小应用，ABP可以给你模板。如果你想提高自己在职场的代码能力，ABP可以一次给你全部的最佳实践。这可以说是ctrl c + v程序员的福音。从这些方面来看，我认为ABP绝对价值连城。

## 主要功能
我们现在就先来打开一个ABP模板运行一下，简单看一下ABP有哪些功能。我们可以从ABP的官网选择我们想要的开发框架。这里可以看到ABP支持angular，React，还有blazor。

### 用户管理
我们可以看到，模板自动继承了用户登录注册的功能。

### 多租户管理
我们可以看到，ABP自动继承了多租户管理的设计。多租户是很多To B Saas软件公司的核心基础功能之一。这个功能一个次概括就是"千人千面"。想象你开发了一个会计软件服务，帮助公司给员工发工资。那么针对每个公司，应用需要提供不同的管理员账户，员工登录方式，不同公司看不到别的公司数据。这就是一个典型的多组合场景，每个公司就是一个租户，在业务底层，每个租户可能需要创建不同的数据库。

### ORM集成
ABP还继承了不同的ORM系统。在这个模板中，我们可以看到，它继承了EF framework。除此之外，ABP还提供了对mongo DB的支持。整个ABP的设计还遵循了ORM indpendency的思路。整个系统可以很轻松的移植到其他的ORM或者数据库系统中，后面我会详细介绍这一点。

### 多语言集成
ABP还有多语言的支持。这可以帮助你的应用能够被更多国家的人使用。

### 付费版：支付，聊天，博客，文件系统，短信系统，邮件系统，UI 主题
市面上还有两款基于ABP开发的商业项目。分别为ABP commerical 和 ABP zero。这两个项目继承了更多功能，比如：支付，聊天，博客，文件系统，短信系统，UI主题等等。这两个商业都提供相似的功能，目前价格为这些。目前我还没有忍痛购买这两个项目的代码。我觉的基础功能可能已经足够一些小项目的开发了。

## 架构
在ABP framework官网上，可以免费下一份ABP的架构电子书。这本书我建议大家都去下载学习一下。里面记录ABP作者设计ABP很多理念和原则。我在这里分享一下这本书一些中心思想。首先ABP的架构采用了DDD+N layer的架构。我们简单过一下这几个layer，presentation layer就是我们常说的UI层，application layer就是我们业务场景层。比如一个电商网站，普通用户访问这个网站，发布商品的商家访问这个网站，和内部网站的管理人员看到这个网站，他们对于商品的修改，产生的业务的逻辑是不同，application主要针对解决这种问题。接下来是domain层。这一层负责核心业务逻辑，也是DDD的内心部分。最后还有一个infra层，这一层包括了所有的第一方和第三方类库，比如，logging，cache，数据库，ORM等等。这里还给出了一个图，是被成为clean architecture的一张图，这张图像一颗洋葱。软件系统的核心就是我们domain定义和逻辑，接着是应用场景层，接着UI，接着是我们的基础架构层。

## 项目结构介绍
我们先来从ABP的项目结构，来对应一下ABP架构。我从ABP模板中又拿了做任务管理的应用来介绍一下ABP项目结构。httpApi, HttpApi.Client, App.Web项目就是我们的presentation层。App.web是是一个asp.net的web服务项目，httpapi是定义服务controller的项目，httpapi.client是当由外部项目需要调用我们的服务的时候，可以把这个项目发布出来，比如一个nuget package，这样别的服务就可以同个这个package来调用我们的项目了。Application和applicationcontract这两个项目对应了我们的业务逻辑场景层。Appication项目就是核心业务逻辑场景的实现。Application contract是一些可以被分享的结构和数据定义。比如interface，或者一些DTO，也就是data transfer object。DTO一般是指服务的输入和输出的数据定义。Domain和domain shared这两个项目是domain层的项目。domain定义了DDD中内心业务部分，domainshared的项目定了domain中可以共享的数据定义。最后是entity framework core项目，这个项目是我们ORM层，也就是我们的基础层，当然了，所有项目中引用的第三方的包，也算作基础架构层。最后有一个DB mirgrator层，这个项目可以帮助我们初始创建这个项目所需要的数据库。可以理解为一种工具，不被列为项目架构中。

## Module design
对于所有项目，依赖关系都是需要被精心设计的。这张图概括了依赖关系。我们的presentation层依赖了application.contract的项目。application contract定义了interface和数据DTO，所以presentation可以只依赖于application contracts，而不是直接依赖于applicaiton层。同时，application contract项目和domain项目依赖于domain。shared的数据，并且application要依赖于domain层。最关键一个部分就是EF core，也就是ORM层，需要依赖于domain层。注意看是EF core依赖于domain，而不是domain依赖于EF core。如果domain依赖于EF core，这样导致的问题就是，如果某一天我们需要换掉数据库或者ORM，我的domain层也需要跟着变，这样的修改代价是巨大的。从这个图中，我们可以清晰的看到，整个项目的核心，应该domain这个部分，所有的项目都应该依赖于这个domain层。我们业务核心开发不应该受任何项目的影响。只要domain是稳定的，其余所有层都应该是可以被频繁修改和替换的。这个ABP架构册中提到，却分domain和application层的核心就是，domain中的逻辑一般是通用于所有应用场景的。而application中层的逻辑是针对于特定场景的。

关于关于依赖管理，ABP还提供了AbpModule这个强大的类库。AbpModule主要完成两件事情，第一呢，就是定义依赖关系。它可以保证这些依赖的模块先被进行配置，主要就是项目和DI的配置。AbpModule保证了模块之间的正确的初始化顺序和生命周一的管理。

第二，abp module也会自动初始化所以继承ISingletonDependency, ITransisentDependency, IScopedDpenedency的类。非常方便，减少了大量的configservice中的配置。这个ABP module的思想设计的非常简洁漂亮。

## DDD
我们来重点看来一些domainlayer的一些重要的点。

### Entity
首先是entity。一个entity就是实体，拥有唯一的标识符id，以及属性。一般需要entity需要有生命周期的管理。entity的代码形态一般是一个实体类，在数据库中一般是一个table。

### ValueObject
接下来是ValueObject，也是就是值对象。值对象一般没有唯一的Id，值对象主要由其相关属性组成的一个整体概念。比如一个地址信息，一般由街道号，街道名称，市，省等信息组成。

### Aggregate
aggregate代表了一组entity和valueobject。一般一个aggregate可作为划分出一个微服务的依据。

### Aggregate root
聚合根是一种特殊的entity。是一个aggregate中的内心部分。聚合根包含了一个聚合的主要逻辑部分。聚合根的主要目的是为了避免由于复杂数据模型缺少统一的业务规则控制，而导致实体之间的数据不一致性的问题。聚合根有点像一个老板，管理者几个entity。别人如果像操作entity，是需要通过聚合根来完成的。

### Repository
Repository就是数据仓库。repository封装了DBMS的访问细节。

### Domain service
是domain中的一个负责协调多个entity或者聚合根的一个服务。名字一般叫什么什么service或者manager。在ABP中，一般以manager结尾。

### Specification
是一种filter。用于查询满足特定条件的数据。

### Domain Event
domain event主要用于微服务架构中，在微服务之间传递消息。

## Unit of work

## Controller

这些就是本期视频的主要内容，在这期时评中我们主要介绍了什么是ABP，如何运行一个ABP模板，以及ABP的项目结构。有了这些知识，我相信你已经可以开始利用ABP进行项目开发了。想要更好的利用ABP，还需要对Domain driven design有深刻的了解，这个话题太大，我会以后用一期单独的视频来介绍。感谢观看，我们下期时评见。
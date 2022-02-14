# 从Domain Driven Design之道谈项目演进
## 开场
我第一次听说domain driven design是在我们公司内部一个技术分享会上，我们组有一个工程师，想要在我们推荐domain driven design这个设计模式。这个技术名词本来是一个还算比较有热度话题性的东西。我当时印象很深，整个会开下来，会议一度非常安静。主持过会的人一定肯定会有感觉，就是开会最怕安静了。因为安静，没人问的出来问题就以为大家真的完全没听懂你在说什么。我当时听下来，心里有种说不出的愤怒。我心理想，大哥你在说些什么，给我整这些repository，entity，valueobject，aggregate root干嘛 ，这都什么鬼。我都没搞懂为什么需要这些概念，你确要解释这么都是些什么概念，并且说服我们要DDD改造。最后的结果就是，大家确实没听懂，也别提什么DDD改造了。

不过我这个人对技术还是有点较真精神，后来还是研究了一些DDD的思路，发现DDD对我的代码书写启发还是巨大的，还是想特地出一期视频来讲解一下DDD这个思想下的道。也就是其底层编程思想。如果你想实打实的利用DDD提高自己的项目代码能力，那么这期视频请一定看完。程序员不同阶段就是要学习一些不同阶段的编程设计模式。在我们刚开始编程的时候，最重要的设计模式就是OOP，也就是Object-Oriented programming。那个时候感觉会写个类，不得了了。后来下个阶段，就是开始学习一些常见design pattern了，比如工厂模型，设配器模型等等，这个时候就是天天捧个design pattern这种书，天天开始套用这个模版写一些代码。再到后来，发现SOLID模型，突然意识SOLID是个好东西，用个这个不仅可以写好代码，还可以给别人留出来一大堆comment。学完这些，你觉的自己有点牛逼，很有代码的感觉，自己代码最好，别人的都是垃圾。到其实目前位置，这些思路大多还是在项目细节层的设计。大多是几个类怎么设计，等等。如果这个时候，你成长为技术骨干了，成为组里的主要码力了，你需要开始做更多宏观项目的设计。这些设计涉及多个模块设计，多个系统集成，正常情况下你会陷入一个迷茫期。就是有点咦，怎么之前学的东西有点不好使了。这个时候你需要学习Domain driven design。

Domain driven design其实是一些设计思想的集合。如果你去看很多文章对domain driven design的介绍，会提到这是一种什么基于domain expert对domain领域设计之类的。这种介绍你基本就晕了，这种文章一般会越看越觉的这个DDD有些邪乎。我自己总结，DDD提供了一组对于软件模块化的指导思想。说白了就是如果把复杂的软件各个部分进行更好的封装。这时候，有观众可能会说了，封装这个概念不是太老生常谈了，扯这么个DDD理论干嘛。确实，DDD其实模块化的一套体系思想，你可能平常可能都在用，但这个理论就把好的设计规律给总结出来。

## 架构来看模块
我们先来看一段我们组服务应用的架构。是一个传统三层架构，presentation，application，infra。他们的依赖关系是这样的：

一开始我们组的代码是这样的：

```C#
public class BusinessCRUDService {
    private ExternalService service;
    private HttpClient httpClient;

    public async Task CreateResource(string resourceid, ResourceRequest request ) {
        if (string.isNullOrEmpty(resourceId) && string.isNullOrEmpty(requestBody)) {
            throw new Exception();
        }

        if (!validId(resourceId) || !validResource(resource)) {
            throw new Exception();
        }

        service.Validate(resourceid);

        var response = httpClient.get();
        if (response.Status != HttpStatus.OK) {
            throw new Exception();
        }

        

    }
}
```
present -> Controllers, auth, audit, limit, BFF
application -> *service
Infra -> Lib, Database

问题：

1. application 太大。业务逻辑容易不清楚。缺乏指导思想
2. infra 依赖性太高。业务技术升级困难
3. 理解业务困难
4. 划分微服务苦难

四层
1. Application
domain infra

现在我们来看一下infra这一层。之前我们面对infra这层最大的问题是依赖关系。由于infra这一层大部分是第三方的类库和轮子，我们希望我们的应用尽可能于infra这一层解耦。所以infra这一层的在架构的位置发生了变化。首先它不应该位置最底层的位置。取而代之的是，它位于和所有层并行的位置，并且依赖于所有层。这样的依赖关系，就解决了关于infra这一层最主要的问题。至于如何实现，其实就是添加一层防腐层对其进行隔离，关于这一点，在视频后面我会讲到。

我们现在再来看一下数据之间传输的数据到底是什么。Application和Presentation传输的是REST DTO。Application和domain之间传的是entity。所以application之一层是要对DTO和entity之间做一个转换。这么做的目的，主要也是为了层与层之间数据结构传输的解耦。可以想象，rest dto是被严格管理，不能随意改动。因为这是和用户的接口，可不能随意修改。而随着domain业务变化，这个entity可能需要承载更多状态，所以需要这个entity是可以随着业务变化而修改的。接着domain和数据库之间也需要传输数据库的dto。数据库的dto也就是我们数据库的schema，是不能被随意修改变动的。这两组数据管理是需要格外注意的。

## 项目结构
domain 
domain.share
application
application.share
web
infra

## 数据转换
DTO -> POJO

## 贫血 vs 充血


## 防腐隔离


## 微服务划分 - 聚合根
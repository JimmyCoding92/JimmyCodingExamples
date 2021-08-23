# 创建一个本地kubernetes集群步骤 - Windows

## 1. 激活hyper-v
https://docs.microsoft.com/zh-cn/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v

## 2. 安装docker desktop
https://docs.docker.com/desktop/windows/install/

## 3. 选择一下三者其一的工具来创建kubernetes集群
* docker desktop: https://docs.docker.com/desktop/kubernetes/
* minikube: https://minikube.sigs.k8s.io/docs/start/
* kind: https://kind.sigs.k8s.io/docs/user/quick-start/

## 4. 安装kubectl工具
* https://kubernetes.io/zh/docs/tasks/tools/

## 5. 开始你的kubernetes集群操作把
常见指令：
* kubectl get nodes 
* kubectl get pods -A
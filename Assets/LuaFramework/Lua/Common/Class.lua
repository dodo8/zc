local function _setMetaTableIndex(table, metaTable)
    local currentMetaTable = getmetatable(table)
    if currentMetaTable then
        currentMetaTable.__index = metaTable --如果table有元表，将其原表的__index 设置为metaTable
    else
        local metatable = { __index = metaTable } --table没有元表，将齐
        setmetatable(table, metatable)--问题：这种做法：设置_index与setmetatable在作用上的区别：setmetatable(table,metatable)不修改——index
    end
end

--类

--基于index和元表的方式实现子类与父类的继承




local function _class(className, ...)
    --创建出来一个类
    local currentClass = { ___className = className } --table

    --传递的父类
    local baseClasses = { ... }--很多个表么？？    可变参数的表达式写作三个点

    local baseClassCount = #baseClasses --#用于取表的大小
    if baseClassCount > 0 then--没有继承直接跳过去
        if baseClassCount > 1 then --多重继承
            _setMetaTableIndex(currentClass, function(_, key)--复制到key？并返回最后一个元素？
                local baseClass
                for i = 1, #baseClasses do
                    baseClass = baseClasses[i]
                    if baseClass[key] then
                        return baseClass[key]--根据上个函数的参数，返回参数值
                    end
                end
            end)
        else
            _setMetaTableIndex(currentClass, baseClasses[1]) --给子类绑定table和__index
        end
    end

    currentClass.New = function(...) --这是在定义新的函数吧？.New表示实例化？  将实例化结果赋值为函数结果

        local instance = { ___isInstance = true }--存储bool变量的数据结构命名为isInstance
        _setMetaTableIndex(instance, currentClass)--进行继承
        if instance.ctor ~= nil then--构造函数？？？？
            instance:ctor(...)
        end
        return instance
    end

    return currentClass
end

--[[
     local function f () body end
被转译成

     local f; f = function () body end

        --和以下的写法的区别呢function currentClass:new (...)    function currentClass.new (self,...)
        --如果使用上面这种方式找不到变量currentClass，因为这样的话你是在声明定义域
]]--





Class = _class



TestA = {}
TestA.protype = {x= 0,y=0, width=100, height=100, }
TestA.value = 1
TestA.value2 = 2

TestB =  {size = 200,money = 400}

TestC = {area = 1,length = 20, breadth = 70}


Test =  Class("Test",TestA,TestB,TestC)

function Test:ctor(value)
    print(value)
end

a = Test.New(10)
local testA=a.money
print(testA)


--[[
Test =  class("Test")
a = Test.New(...)
local testA=a.TestValue
baseClass["TestValue"]


local test={}
test["TestValue"]=1
test.TestValue=1

local value=test.TestValue
local value=test["TestValue"]
]]--




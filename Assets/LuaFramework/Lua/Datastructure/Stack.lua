module("System", package.seeall)

local _base = BaseDataStructure
--栈
---@class Stack:BaseDataStructure
Stack = Class("Stack", _base)--继承

function Stack:ctor()
    _base.ctor(self)
end

--入栈
function Stack:Push(data)
    self:_addData(data)
end

--出栈
function Stack:Pop()
    return self:_getAndRemoveTop()
end

--查看栈顶数据
function Stack:Peek()
    return self:_peekTop()
end

--父类调用
function Stack:_getTopIndex()
    return self._count
end

--父类调用
function Stack:_getDistanceTopIndex(count)
    return self._dataCount + 1 - count
end


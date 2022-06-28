---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by LilithGames.
--- DateTime: 2021/7/9 11:45
---

--想法是用栈实现队列


module("System", package.seeall)

local _base = BaseDataStructure

Deque = Class("Deque",_base)

function Deque:ctor()
    _base:ctor(self)
end

function Deque:Dequeue() --头部出队
    return self:_getAndRemoveTop()
end

function Deque:Enqueue(data) --尾部入队
    table.insert(self._dataList, 1,data)
    self._dataCount = self._dataCount + 1
end


function Deque:ToTable (TargetTable)
    for i = self._dataCount, 1, -1 do
        table.insert(TargetTable,_dataList[i])
    end
end

function Deque:TrimToSize()   --设置容量为 Queue 中元素的实际个数

end

--父类调用————重写
--获取队头数据位置
function Deque:_getTopIndex()
    return 1
end

--获得距离队尾Count数量的Index
function Deque:_getDistanceTopIndex(count)
    return self._dataCount + 1 - count
end

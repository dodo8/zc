module("System", package.seeall)

--数据结构的基类
---@class BaseDataStructure
BaseDataStructure = Class("BaseDataStructure")

function BaseDataStructure:ctor()
    --数据列表
    self._dataList = {}
    --数据个数
    self._dataCount = 0
end

--是否包含
function BaseDataStructure:IsContains(data)
    if self._dataCount == 0 then
        return false
    end
    for i = self._dataCount, 1, -1 do
        if self._dataList[i] == data then  --递减
            return true
        end
    end
    return false
end

--移除数据
function BaseDataStructure:Remove(data)
    if self._dataCount == 0 then
        return
    end
    for i = self._dataCount, 1, -1 do
        if self._dataList[i] == data then
            table.remove(self._dataList, i)
            self._dataCount = self._dataCount - 1
            break
        end
    end
end

--清除
function BaseDataStructure:Clear()
    self._dataList = {}
    self._dataCount = 0
end

--取数量
function BaseDataStructure:GetCount()
    return self._dataCount
end

--迭代器，用来遍历
function BaseDataStructure:Iterator(index)
    local currentIndex = self:_getDistanceTopIndex(index)
    if currentIndex <= 0 then
        return nil, nil
    end
    if currentIndex > self._dataCount then
        return nil, nil
    end
    return index + 1, self._dataList[currentIndex]
end

--添加数据
function BaseDataStructure:_addData(data)
    table.insert(self._dataList, data)
    self._dataCount = self._dataCount + 1
end

--取顶部数据并移除
function BaseDataStructure:_getAndRemoveTop()
    if self._dataCount == 0 then
        return nil
    end
    local topIndex = self:_getTopIndex()
    local data = self._dataList[topIndex]
    table.remove(self._dataList, topIndex)
    self._dataCount = self._dataCount - 1
    return data
end

--查看顶部的数据
function BaseDataStructure:_peekTop()
    if self._dataCount == 0 then
        return nil
    end
    return self._dataList[self:_getTopIndex()]
end

--取顶部的Index
function BaseDataStructure:_getTopIndex()  --因为涉及到不同的数据结构吗
    LogError("需要子类覆写")
end

--获得距离顶部Count数量的Index
--1为顶部
function BaseDataStructure:_getDistanceTopIndex(count)
    LogError("需要子类覆写")
end

return BaseDataStructure





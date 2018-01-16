module Wyvern.EntityComponentSystem

open System

type IComponent =
  abstract member Name: string

type EntityId = EntityId of Guid

type ITagged =
  abstract member Tags: int

type IEntity =
  inherit ITagged

  abstract member Id: EntityId
  abstract member Components: IComponent list

type ISystem = interface end

type IEntityManager =
  abstract member AddEntity: IEntity -> unit

let makeEntityManager () =
  let mutable entities = []
  {
    new IEntityManager with
      member __.AddEntity entity =
        entities <- entity :: entities
  }

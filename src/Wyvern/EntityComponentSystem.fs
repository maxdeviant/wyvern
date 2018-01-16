namespace Wyvern.EntityComponentSystem

open System

// @TODO Move to core/engine?
type ITagged =
  abstract member Tags: int

type EntityId = EntityId of Guid

type IComponent =
  abstract member Id: ComponentId.T
  abstract member Name: string

type IEntity =
  inherit ITagged

  abstract member Id: EntityId
  abstract member Components: IComponent list

type ISystem = interface end

type IEntityManager =
  abstract member AddEntity: IEntity -> unit

module EntityManager =
  let makeEntityManager () =
    let mutable entities = []
    {
      new IEntityManager with
        member __.AddEntity entity =
          entities <- entity :: entities
    }

module ComponentIdGenerator =
  let mutable private id = 0
  let next() =
    id <- id + 1
    id

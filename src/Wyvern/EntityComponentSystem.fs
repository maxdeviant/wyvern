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
  abstract member Id: EntityId

type ISystem = interface end

type IEntityManager<'TEntity when 'TEntity :> IEntity> =
  abstract member Entities: (IEntity -> bool) -> IEntity list
  abstract member AddEntity: IEntity -> unit

module EntityManager =
  let makeEntityManager<'TEntity when 'TEntity :> IEntity> () =
    let mutable entities = []
    {
      new IEntityManager<'TEntity> with
        member __.Entities predicate =
          entities
          |> List.filter predicate
        member __.AddEntity entity =
          entities <- entity :: entities
    }

module ComponentIdGenerator =
  let mutable private id = 0
  let next() =
    id <- id + 1
    id

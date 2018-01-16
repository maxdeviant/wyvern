module Wyvern.Entities

open System
open Wyvern.Components

type EntityId = EntityId of Guid

type ITagged =
  abstract member Tags: int

type IEntity =
  inherit ITagged
  abstract member Id: EntityId
  abstract member Components: IComponent list

type IEntityManager =
  abstract member AddEntity: IEntity -> unit

let makeEntityManager () =
  let mutable entities = []

  {
    new IEntityManager with
      member __.AddEntity entity =
        entities <- entity :: entities
  }

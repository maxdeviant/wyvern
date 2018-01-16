namespace Wyvern

open Wyvern.EntityComponentSystem
open Engine
open Graphics
open System
open EntityComponentSystem.EntityManager

[<AbstractClass>]
type WyvernGame<'TEntity when 'TEntity :> IEntity>() as this =
  let engine = new GameEngine<'TEntity>(this.LoadContent, this.UnloadContent, this.Update, this.Render)

  member __.EntityManager = makeEntityManager<'TEntity>()
  member __.TextureManager = makeTextureManager engine.GraphicsDevice engine.Content.RootDirectory

  abstract member LoadContent: unit -> unit
  default __.LoadContent() =
    ()

  abstract member UnloadContent: unit -> unit
  default __.UnloadContent() =
    ()
    
  abstract member Update: DeltaTime -> unit

  abstract member Render: (DrawRequest -> unit) -> DeltaTime -> unit

  member __.Run() =
    engine.Run()

  interface IDisposable with
    override __.Dispose() =
      engine.Dispose()

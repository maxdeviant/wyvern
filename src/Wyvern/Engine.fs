module Wyvern.Engine

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System
open Units
open Wyvern.EntityComponentSystem
open Wyvern.Graphics

type DeltaTime = float<s>

type DrawRequest =
  | Skip
  | Texture of texture: Texture * position: Wyvern.Vector2 * color: Wyvern.Color

type FpsCounter() =
  let oneSecond = TimeSpan.FromSeconds 1.0

  let mutable elapsedTime = TimeSpan.Zero
  let mutable frameCount = 0
  let mutable frameRate = 0

  member __.Fps with get() = frameRate

  member __.Update(gameTime: GameTime) =
    elapsedTime <- elapsedTime + gameTime.ElapsedGameTime
    if elapsedTime > oneSecond then
      elapsedTime <- elapsedTime - oneSecond
      frameRate <- frameCount
      frameCount <- 0

  member __.Draw() =
    frameCount <- frameCount + 1

type private GameEngine(loadContent: IEntityManager -> ITextureManager -> unit, unloadContent: unit -> unit, update: DeltaTime -> unit, render: ITextureManager -> (DrawRequest -> unit) -> DeltaTime -> unit) as this =
  inherit Game()

  do this.IsFixedTimeStep <- false
  do this.Content.RootDirectory <- @"Content"
  let graphics = new GraphicsDeviceManager(this)
  // @TODO Set vsync based on user settings.
  do graphics.SynchronizeWithVerticalRetrace <- false

  let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>
  let mutable textureManager = Unchecked.defaultof<ITextureManager>
  let entityManager = makeEntityManager()
  let fpsCounter = FpsCounter()

  let getDeltaTime (gameTime: GameTime): DeltaTime =
    LanguagePrimitives.FloatWithMeasure gameTime.ElapsedGameTime.TotalSeconds

  let requestDraw drawRequest =
    match drawRequest with
    | Skip -> ()
    | Texture(texture, position, color) -> spriteBatch.Draw(texture.Texture, MonoGameInterop.toVector2 position, MonoGameInterop.toColor color)

  override __.Initialize() =
    base.Initialize()

  override __.LoadContent() =
    spriteBatch <- new SpriteBatch(__.GraphicsDevice)
    textureManager <- makeTextureManager __.GraphicsDevice __.Content.RootDirectory
    loadContent entityManager textureManager

  override __.UnloadContent() =
    unloadContent()

  override __.Update gameTime =
    update (getDeltaTime gameTime)
    base.Update gameTime
    fpsCounter.Update gameTime

  override __.Draw gameTime =
    spriteBatch.Begin(samplerState = SamplerState.PointClamp)
    render textureManager requestDraw (getDeltaTime gameTime)
    spriteBatch.End()
    base.Draw gameTime
    __.Window.Title <- sprintf "[%d fps]" fpsCounter.Fps
    fpsCounter.Draw()

let init loadContent unloadContent update render =
  let run () =
    use engine = new GameEngine(loadContent, unloadContent, update, render)
    engine.Run()

  run

package bowling

class GameTests {
  import org.junit.Before
  import org.junit.Test
  import org.junit.Assert._

  val twentyZeroesRolls = List.fill(20)(0)
  val twentyOnesRolls = List.fill(20)(1)
  val twelveStrikes = List.fill(12)(10)
  val game = Game

  @Before
  def initialize() {
  }

  @Test
  def gutterGame() {
    assertEquals(0, game.roll(twentyZeroesRolls))
  }

  @Test
  def allOnesGame() {
    assertEquals(20, game.roll(twentyOnesRolls))
  }

  @Test
  def spareGame() {
    val rolls = List(5, 5, 3) ++ List.fill(17)(0)

    assertEquals(16, game.roll(rolls))
  }

  @Test
  def oneStrikeGame() {
    val rolls = List(10, 3, 4) ++ List.fill(16)(0)

    assertEquals(24, game.roll(rolls))
  }

  @Test
  def perfectGame() {
    assertEquals(300, game.roll(twelveStrikes))
  }

  @Test
  def almostPerfectGame() {
    val rolls = List.fill(9)(10) ++ List(5, 5)

    assertEquals(265, game.roll(rolls))
  }

}

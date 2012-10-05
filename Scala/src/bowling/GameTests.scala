package bowling

import org.junit.Before

/**
 * Created with IntelliJ IDEA.
 * User: Saulis
 * Date: 5.10.2012
 * Time: 20:54
 * To change this template use File | Settings | File Templates.
 */
class GameTests {
  import org.junit.Test
  import org.junit.Assert._

  val twentyZeroesRolls = List.fill(20)(0)
  val twentyOnesRolls = List.fill(20)(1)
  val game = Game

  @Before
  def initialize() {
  }

  @Test
  def gutterGame() {
    val points = game.roll(twentyZeroesRolls)

    assertEquals(0, points)
  }

  @Test
  def allOnesGame() {
    val points = game.roll(twentyOnesRolls)

    assertEquals(20, points)
  }

  @Test
  def spareGame() {
    val rolls = List(5, 5, 3) ++ List.fill(17)(0)

    assertEquals(16, game.roll(rolls))
  }
}

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

  val twentyZeroes = List.fill(20)(0)
  val twentyOnes = List.fill(20)(1)
  val game = Game

  @Before
  def initialize() {
  }

  @Test
  def gutterGame() {
    val points = game.roll(twentyZeroes)

    assertEquals(0, points)
  }


  @Test
  def allOnesGame() {
    val points = game.roll(twentyOnes)

    assertEquals(20, points)
  }
}

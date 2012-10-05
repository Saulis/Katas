package bowling

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

  @Test
  def gutterGame() {
       val game = Game
       val points = game.roll(twentyZeroes)
       assertEquals(0, points)
  }
}

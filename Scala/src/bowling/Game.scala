package bowling

/**
 * Created with IntelliJ IDEA.
 * User: Saulis
 * Date: 5.10.2012
 * Time: 20:52
 * To change this template use File | Settings | File Templates.
 */
object Game {

  private def sumOfNextThreeRolls(pins: List[Int]): Int = {
    pins.take(3).sum
  }

  private def sumOfNextTwoRolls(pins: List[Int]): Int = {
    pins.take(2).sum
  }

  private def lastFrameEndsWithStrike(pins: List[Int]): Boolean = {
    pins.length == 3 & nextRollIsStrike(pins)
  }

  private def lastFrame(frame: Int): Boolean = frame == 10

  private def lastFrameTotal(pins: List[Int]): Int = {
    pins.sum
  }

  private def frameTotal(frame: Int, pins: List[Int]): Int = {
    if (lastFrame(frame))
      lastFrameTotal(pins)
    else if (nextRollIsStrike(pins))
      sumOfNextThreeRolls(pins) + frameTotal(frame + 1, pins.drop(1))
    else if (frameEndsWithSpare(pins))
      sumOfNextThreeRolls(pins) + frameTotal(frame + 1, pins.drop(2))
    else
      sumOfNextTwoRolls(pins) + frameTotal(frame + 1, pins.drop(2))
  }

  private def nextRollIsStrike(pins: List[Int]) : Boolean = {
    pins.head == 10
  }

  private def frameEndsWithSpare(pins: List[Int]) : Boolean = {
    (!nextRollIsStrike(pins) & sumOfNextTwoRolls(pins) == 10)
  }

  private def pinsRemain(pins: List[Int]): Boolean = {
    pins.length > 0
  }

  def roll (pins: List[Int]): Int =  {
    frameTotal(1, pins)
   }
}

package bowling

/**
 * Created with IntelliJ IDEA.
 * User: Saulis
 * Date: 5.10.2012
 * Time: 20:52
 * To change this template use File | Settings | File Templates.
 */
object Game {

  private def totalForRemainingPins(pins: List[Int]): Int = {
    if (pinsRemain(pins))
      frameTotal(pins)
    else {
      0
    }
  }

  private def sumOfNextThreeRolls(pins: List[Int]): Int = {
    pins.take(3).sum
  }

  private def sumOfNextTwoRolls(pins: List[Int]): Int = {
    pins.take(2).sum
  }

  private def frameTotal(pins: List[Int]): Int = {
    if (frameEndsWithStrike(pins))
      sumOfNextThreeRolls(pins) + totalForRemainingPins(pins.drop(1))
    else if (frameEndsWithSpare(pins))
      sumOfNextThreeRolls(pins) + totalForRemainingPins(pins.drop(2))
    else
      sumOfNextTwoRolls(pins) + totalForRemainingPins(pins.drop(2))
  }

  private def frameEndsWithStrike(pins: List[Int]) : Boolean = {
    pins.head == 10
  }

  private def frameEndsWithSpare(pins: List[Int]) : Boolean = {
    (!frameEndsWithStrike(pins) & sumOfNextTwoRolls(pins) == 10)
  }

  private def pinsRemain(pins: List[Int]): Boolean = {
    pins.length > 0
  }

  def roll (pins: List[Int]): Int =  {
     totalForRemainingPins(pins)
   }
}

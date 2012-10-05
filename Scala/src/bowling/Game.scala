package bowling

/**
 * Created with IntelliJ IDEA.
 * User: Saulis
 * Date: 5.10.2012
 * Time: 20:52
 * To change this template use File | Settings | File Templates.
 */
object Game {

  def spareTotal(pins: List[Int]): Int = {
    pins.take(3).sum
  }

  def framePoints(pins: List[Int]): Int = {
    if (pinsRemain(pins))
      if (frameEndsWithSpare(pins))
        spareTotal(pins) + framePoints(pins.drop(2))
      else
        pins.head + framePoints(pins.drop(1))
    else {
      0
    }
  }

  def frameEndsWithStrike(pins: List[Int]) : Boolean = {
    pins.head == 10
  }

  def frameEndsWithSpare(pins: List[Int]) : Boolean = {
    (!frameEndsWithStrike(pins) & pins.take(2).sum == 10)
  }

  def pinsRemain(pins: List[Int]): Boolean = {
    pins.length > 0
  }

  def roll (pins: List[Int]): Int =  {
     framePoints(pins)
   }
}

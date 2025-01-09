import React from 'react'
import coat  from '../../../assets/images/icons/coat.svg';
import glasses  from '../../../assets/images/icons/glasses.svg';
import shorts  from '../../../assets/images/icons/shorts.svg';
import tee  from '../../../assets/images/icons/tee.svg';
import jacket  from '../../../assets/images/icons/jacket.svg';
import watch  from '../../../assets/images/icons/watch.svg';
import hat  from '../../../assets/images/icons/hat.svg';
import dress  from '../../../assets/images/icons/dress.svg';
function MenuCategoryH() {
  return (
    <div className="category">
    <div className="container">
      <div className="category-item-container has-scrollbar">
        <div className="category-item">
          <div className="category-img-box">
            <img src={dress} alt="dress & frock" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">Dress &amp; frock</h3>
              <p className="category-item-amount">(53)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
        <div className="category-item">
          <div className="category-img-box">
            <img src={coat} alt="winter wear" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">Winter wear</h3>
              <p className="category-item-amount">(58)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
        <div className="category-item">
          <div className="category-img-box">
            <img src={glasses} alt="glasses & lens" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">Glasses &amp; lens</h3>
              <p className="category-item-amount">(68)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
        <div className="category-item">
          <div className="category-img-box">
            <img src={shorts} alt="shorts & jeans" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">Shorts &amp; jeans</h3>
              <p className="category-item-amount">(84)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
        <div className="category-item">
          <div className="category-img-box">
            <img src={tee} alt="t-shirts" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">T-shirts</h3>
              <p className="category-item-amount">(35)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
        <div className="category-item">
          <div className="category-img-box">
            <img src={jacket} alt="jacket" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">Jacket</h3>
              <p className="category-item-amount">(16)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
        <div className="category-item">
          <div className="category-img-box">
            <img src={watch} alt="watch" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">Watch</h3>
              <p className="category-item-amount">(27)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
        <div className="category-item">
          <div className="category-img-box">
            <img src={hat} alt="hat & caps" width={30} />
          </div>
          <div className="category-content-box">
            <div className="category-content-flex">
              <h3 className="category-item-title">Hat &amp; caps</h3>
              <p className="category-item-amount">(39)</p>
            </div>
            <a href="#" className="category-btn">Show all</a>
          </div>
        </div>
      </div>
    </div>
  </div>
  )
}

export default MenuCategoryH
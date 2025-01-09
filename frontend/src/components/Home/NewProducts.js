import React, { useEffect, useState } from 'react'
import axios from 'axios';
import baseURL from '../../api/BaseUrl';
import ImageProduct from './ImageProduct';
import ImageProductThumb from './ImageProductThumb';
import ImageProductShow from './ImageProductShow';
import { IonIcon } from '@ionic/react';
import { bagAddOutline, eyeOutline, heartOutline, repeatOutline, star, starOutline } from 'ionicons/icons';
function NewProducts() {
    const [products, setProducts] = useState([]);
    const [arr, setArr] = useState([])
    const [tren, setTren] = useState([])
    const [top, setTop] = useState([])
    const [deals, setDeals] = useState([])
    useEffect(() => {

        axios.get(baseURL + `Product/Tag/` + encodeURIComponent("New Products"))
            .then(response => {


                setProducts(response.data);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
            });
        axios.get(baseURL + `Product/Tag/` + encodeURIComponent("New Arrivals"))
            .then(response => {


                setArr(response.data);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
            });
        axios.get(baseURL + `Product/Tag/` + encodeURIComponent("Trending"))
            .then(response => {


                setTren(response.data);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
            });
        axios.get(baseURL + `Product/Tag/` + encodeURIComponent("Top Rated"))
            .then(response => {


                setTop(response.data);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
            });
        axios.get(baseURL + `Product/Tag/` + encodeURIComponent("Deal of the day"))
            .then(response => {


                setDeals(response.data);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
            });

    }, []);
    // const tagData = [
    //   {
    //     "name": "New Arrivals",
    //   },
    //   {
    //     "name": "Trending",
    //   },
    //   {
    //     "name": "Top Rated",
    //   },
    // ]


    return (
        <div className="product-box">

            <div className="product-minimal">

                {arr.length > 0 && (
                    <div className="product-showcase">
                        <h2 className="title">New Arrivals</h2>
                        <div className="showcase-wrapper has-scrollbar">
                            {arr.length > 0 && (
                                <div className="showcase-container">
                                    {arr.slice(0, 4).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                            {arr.length > 4 && (
                                <div className="showcase-container">
                                    {arr.slice(4, 8).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                            {arr.length > 8 && (
                                <div className="showcase-container">
                                    {arr.slice(8, 12).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                        </div>
                    </div>

                )}

                {tren.length > 0 && (
                    <div className="product-showcase">
                        <h2 className="title">Trending</h2>
                        <div className="showcase-wrapper  has-scrollbar">
                            {tren.length > 0 && (
                                <div className="showcase-container">
                                    {tren.slice(0, 4).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                            {tren.length > 4 && (
                                <div className="showcase-container">
                                    {tren.slice(4, 8).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                            {tren.length > 8 && (
                                <div className="showcase-container">
                                    {tren.slice(8, 12).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                        </div>
                    </div>
                )}
                {top.length > 0 && (
                    <div className="product-showcase">
                        <h2 className="title">Top Rated</h2>
                        <div className="showcase-wrapper  has-scrollbar">
                            {top.length > 0 && (
                                <div className="showcase-container">
                                    {top.slice(0, 4).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                            {top.length > 4 && (
                                <div className="showcase-container">
                                    {top.slice(4, 8).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                            {top.length > 8 && (
                                <div className="showcase-container">
                                    {top.slice(8, 12).map((product) => (
                                        <div className="showcase" key={product.id}>
                                            <a href="#" className="showcase-img-box">
                                                <ImageProductThumb id={product.id} name={product.productName} />
                                            </a>
                                            <div className="showcase-content">
                                                <a href="#">
                                                    <h4 className="showcase-title">{product.productName}</h4>
                                                </a>
                                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                                <div className="price-box">
                                                    <p className="price">${product.salePrice}.00</p>
                                                    <del>${product.buyingPrice}.00</del>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                        </div>
                    </div>
                )}
            </div>
            {/*
      - PRODUCT FEATURED
    */}
            {deals.length > 0 && (
                <div className="product-featured">
                    <h2 className="title">Deal of the day</h2>
                    <div className="showcase-wrapper has-scrollbar">
                        {deals.map((product) => (
                            <div className="showcase-container" key={product.id}>
                                <div className="showcase">
                                    <div className="showcase-banner">
                                        <ImageProductShow id={product.id} name={product.productName} />
                                    </div>
                                    <div className="showcase-content">
                                        <div className="showcase-rating">
                                            <IonIcon icon={star} />
                                            <IonIcon icon={star} />
                                            <IonIcon icon={star} />
                                            <IonIcon icon={starOutline} />
                                            <IonIcon icon={starOutline} />
                                        </div>
                                        <a href="#">
                                            <h3 className="showcase-title">{product.productName}</h3>
                                        </a>
                                        <p className="showcase-desc">
                                            {product.productDescription}
                                        </p>
                                        <div className="price-box">
                                            <p className="price">${product.salePrice}.00</p>
                                            <del>${product.buyingPrice}.00</del>
                                        </div>
                                        <button className="add-cart-btn">add to cart</button>
                                        <div className="showcase-status">
                                            <div className="wrapper">
                                                <p>
                                                    already sold: <b>20</b>
                                                </p>
                                                <p>
                                                    available: <b>0</b>
                                                </p>
                                            </div>
                                            <div className="showcase-status-bar" />
                                        </div>
                                        <div className="countdown-box">
                                            <p className="countdown-desc">
                                                Hurry Up! Offer ends in:
                                            </p>
                                            <div className="countdown">
                                                <div className="countdown-content">
                                                    <p className="display-number">360</p>
                                                    <p className="display-text">Days</p>
                                                </div>
                                                <div className="countdown-content">
                                                    <p className="display-number">24</p>
                                                    <p className="display-text">Hours</p>
                                                </div>
                                                <div className="countdown-content">
                                                    <p className="display-number">59</p>
                                                    <p className="display-text">Min</p>
                                                </div>
                                                <div className="countdown-content">
                                                    <p className="display-number">00</p>
                                                    <p className="display-text">Sec</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        ))}

                        {/* <div className="showcase-container">
              <div className="showcase">
                <div className="showcase-banner">
                  <img src={require("../../assets/images/products/jewellery-1.jpg")} alt="Rose Gold diamonds Earring" className="showcase-img" />
                </div>
                <div className="showcase-content">
                  <div className="showcase-rating">
                    <IonIcon icon={star} />
                    <IonIcon icon={star} />
                    <IonIcon icon={star} />
                    <IonIcon icon={starOutline} />
                    <IonIcon icon={starOutline} />
                  </div>
                  <h3 className="showcase-title">
                    <a href="#" className="showcase-title">Rose Gold diamonds Earring</a>
                  </h3>
                  <p className="showcase-desc">
                    Lorem ipsum dolor sit amet consectetur Lorem ipsum
                    dolor dolor sit amet consectetur Lorem ipsum dolor
                  </p>
                  <div className="price-box">
                    <p className="price">$1990.00</p>
                    <del>$2000.00</del>
                  </div>
                  <button className="add-cart-btn">add to cart</button>
                  <div className="showcase-status">
                    <div className="wrapper">
                      <p> already sold: <b>15</b> </p>
                      <p> available: <b>40</b> </p>
                    </div>
                    <div className="showcase-status-bar" />
                  </div>
                  <div className="countdown-box">
                    <p className="countdown-desc">Hurry Up! Offer ends in:</p>
                    <div className="countdown">
                      <div className="countdown-content">
                        <p className="display-number">360</p>
                        <p className="display-text">Days</p>
                      </div>
                      <div className="countdown-content">
                        <p className="display-number">24</p>
                        <p className="display-text">Hours</p>
                      </div>
                      <div className="countdown-content">
                        <p className="display-number">59</p>
                        <p className="display-text">Min</p>
                      </div>
                      <div className="countdown-content">
                        <p className="display-number">00</p>
                        <p className="display-text">Sec</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div> */}
                    </div>
                </div>
            )}
            {/*
      - PRODUCT GRID
    */}

            <div className="product-main">
                <h2 className="title">New Products</h2>
                <div className="product-grid">
                    {products.slice(0, 12).map(product => (
                        <div key={product.id} className="showcase">

                            <div className="showcase-banner" key={product.id}>
                                <ImageProduct id={product.id} name={product.productName} />
                                <div className="showcase-actions">
                                    <button className="btn-action">
                                        {/* <IonIcon name="heart-outline" /> */}
                                        <IonIcon icon={heartOutline} />
                                    </button>
                                    <button className="btn-action">
                                        <IonIcon icon={eyeOutline} />
                                    </button>
                                    <button className="btn-action">
                                        <IonIcon icon={repeatOutline} />
                                    </button>
                                    <button className="btn-action">
                                        <IonIcon icon={bagAddOutline} />
                                    </button>
                                </div>
                            </div>
                            <div className="showcase-content">
                                <a href="#" className="showcase-category">{product.productCategoryNames[0]}</a>
                                <a href="#">
                                    <h3 className="showcase-title">{product.productName}</h3>
                                </a>
                                <div className="showcase-rating">
                                    <IonIcon icon={star} />
                                    <IonIcon icon={star} />
                                    <IonIcon icon={star} />
                                    <IonIcon icon={starOutline} />
                                    <IonIcon icon={starOutline} />
                                </div>
                                <div className="price-box">
                                    <p className="price">${product.salePrice}.00</p>
                                    <del>${product.buyingPrice}.00</del>
                                </div>
                            </div>

                        </div>
                    ))}

                </div>
            </div>
        </div>
    )
}

export default NewProducts

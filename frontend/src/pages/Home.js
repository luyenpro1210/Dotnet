import React from "react";

import Slider from "../components/Home/Slider";
import MenuCategoryH from "../components/Home/MenuCategory/MenuCategoryH";
import NewProducts from "../components/Home/NewProducts";
import Blog from "../components/Home/Blog";
import Testimonial from "../components/Home/Testimonial";
import MenuCategoryProductV from "../components/Home/MenuCategory/MenuCategoryProductV";

function Home() {
  
  return (
    <main>
      <Slider />
      <MenuCategoryH />
      <div className="product-container">
        <div className="container">
        
          <MenuCategoryProductV />
          <NewProducts />
        </div>
      </div>
      <Testimonial />
      <Blog />
    </main>
  );
}

export default Home;

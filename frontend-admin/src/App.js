import logo from './logo.svg';
import './App.css';
import React, { Component } from 'react';
import { Container, CssBaseline } from '@mui/material';
import MenuTop from './components/MenuTop';
import { Routes, Route } from 'react-router-dom';
import Home from './components/Home';
import Product from './components/Product';
import EditProduct from './components/EditProduct';
import ProductTags from './components/ProductTags';
import ProductTagAdd from './components/PRoductTagAdd';
import Gallery from './components/Gallery';
import ProductTagEdit from './components/ProductTagEdit';
import Category from './components/Category';
import CategoryAdd from './components/CategoryAdd';
import CategoryEdit from './components/CategoryEdit';


export default class App extends Component {
    displayName = App.name;

    render() {
        return (
            <React.Fragment>
                <CssBaseline />
                <MenuTop />
                <Container maxWidth="md">
                    <Routes>
                        <Route exact path="/" element={<Home />} />
                        <Route path="/home" element={<Home />} />
                        <Route path="/products" element={<Product />} /> {/* Sử dụng element thay vì component */}
                        <Route path="/edit/product/:id" element={<EditProduct />} />
                        <Route path="/trending" element={<ProductTags tagName="Trending" />} />
                        <Route path="/newarrivals" element={<ProductTags tagName="New Arrivals" />} />
                        <Route path="/toprated" element={<ProductTags tagName="Top Rated" />} />
                        <Route path="/deals" element={<ProductTags tagName="Deal Of The Day" />} />
                        <Route path="/sellers" element={<ProductTags tagName="BEST SELLERS" />} />
                        <Route path="/new" element={<ProductTags tagName="New Products" />} />
                        <Route path="/producttags" element={<ProductTagAdd />} />
                        <Route path="/edit/producttags/:ProductId/:TagId" element={<ProductTagEdit />} />
                        <Route path="/gallery" element={<Gallery />} />
                        <Route path="/category" element={<Category />} />
                        <Route path="/category/add" element={<CategoryAdd />} />
                        <Route path="/category/edit/:id" element={<CategoryEdit />} />

                    </Routes>
                </Container>
            </React.Fragment>
        );
    }
}
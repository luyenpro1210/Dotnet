import { makeStyles } from "@mui/styles";
import React from "react";
import { Link } from "react-router-dom";
import { AppBar, IconButton, Toolbar, Typography } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import MenuItem from "@mui/material/MenuItem";
import Menu from "@mui/material/Menu";
import MoreVertIcon from "@mui/icons-material/Menu";
import CategoryAdd from "./CategoryAdd";

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    flexGrow: 1,
  },
  title: {
    flexGrow: 1,
  },
  linkTo: {
    textDecoration: "none",
    color: "#000",
  },
  linkHome: {
    textDecoration: "none",
    color: "#fff",
  },
}));
export default function MenuTop() {
  const classes = useStyles();
  const [anchorEl, setAnchorEl] = React.useState(null);
  const isMenuOpen = Boolean(anchorEl);
  const handleProfileMenuOpen = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleMenuClose = () => {
    setAnchorEl(null);
  };
  const menuId = "primary-search-account-menu";
  const renderMenu = (
    <Menu
      anchorEl={anchorEl}
      anchorOrigin={{ vertical: "top", horizontal: "right" }}
      id={menuId}
      keepMounted
      transformOrigin={{ vertical: "top", horizontal: "right" }}
      open={isMenuOpen}
      onClose={handleMenuClose}
    >
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/products"} className={classes.linkTo}>
          Product Add
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/producttags"} className={classes.linkTo}>
          Product Tag Add
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/gallery"} className={classes.linkTo}>
          Gallery Add
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/category/add"} className={classes.linkTo}>
          Category Add
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/category"} className={classes.linkTo}>
          Category
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/newarrivals"} className={classes.linkTo}>
          New Arrivalss
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/trending"} className={classes.linkTo}>
          Trending
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/toprated"} className={classes.linkTo}>
          Top Rated
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/deals"} className={classes.linkTo}>
          Deal Of The Day
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/sellers"} className={classes.linkTo}>
          Best Sellers
        </Link>
      </MenuItem>
      <MenuItem onClick={handleMenuClose}>
        <Link to={"/new"} className={classes.linkTo}>
          New Products
        </Link>
      </MenuItem>
    </Menu>
  );
  return (
    <div className={classes.root}>
      <AppBar position="static" color="default">
        <Toolbar>
          <IconButton edge="start" color="inherit" aria-label="menu">
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" className={classes.title}>
            <Link
              to={"/"}
              className={classes.linkHome}
              style={{ color: "black" }}
            >
              Duong Hong Luyen
            </Link>
          </Typography>
          <IconButton
            edge="emd"
            color="inherit"
            aria-label="MoreVert"
            aria-controls={menuId}
            aria-haspopup="true"
            onClick={handleProfileMenuOpen}
          >
            <MoreVertIcon />
          </IconButton>
        </Toolbar>
      </AppBar>
      {renderMenu}
    </div>
  );
}

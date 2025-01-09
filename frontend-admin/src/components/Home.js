import React, { useEffect, useState } from "react";
import { makeStyles } from "@mui/styles";
import Paper from "@mui/material/Paper";
import Grid from "@mui/material/Grid";
import Alert from "@mui/material/Alert";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";
import Button from "@mui/material/Button";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import { Link } from "react-router-dom";
import { DELETE_PRODUCT_ID, GET_ALL_PRODUCTS } from "../api/apiService";

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        marginTop: 20,
    },
    paper: {
        width: "100%",
        margin: "auto",
    },
    removeLink: {
        textDecoration: "none",
    },
}));

export default function Home() {
    const classes = useStyles();
    const [products, setProducts] = useState([]);
    const [checkDeleteProduct, setCheckDeleteProduct] = useState(false);
    const [close, setClose] = useState(false);

    useEffect(() => {
        GET_ALL_PRODUCTS("Product").then((item) => setProducts(item.data));
    }, []);

    //const RawHTML = ({ body, className }) => (
    //    <div
    //        className={className}
    //        dangerouslySetInnerHTML={{ __html: body.replace(/\n/g, "<br />") }}
    //    />
    //);

    const deleteProductID = (id) => {

        DELETE_PRODUCT_ID(`Product/${id}`).then((item) => {
            console.log(item);
            if (item.status === 204) {
                setCheckDeleteProduct(true);
                // setProducts(products.filter((key) => key.idProduct !== id));
                GET_ALL_PRODUCTS("Product").then((item) => setProducts(item.data));
            }
        });
    };
    console.log(products);
    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        {checkDeleteProduct && (
                            <Alert
                                action={
                                    <IconButton
                                        aria-label="close"
                                        color="inherit"
                                        size="small"
                                        onClick={() => {
                                            setClose(true);
                                            setCheckDeleteProduct(false);
                                        }}
                                    >
                                        <CloseIcon fontSize="inherit" />
                                    </IconButton>
                                }
                            >
                                Delete successfully
                            </Alert>
                        )}
                        <TableContainer component={Paper}>
                            <Table className={classes.table} aria-label="simple table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell style={{ fontWeight: "bold" }}>Title</TableCell>
                                        <TableCell style={{ fontWeight: "bold" }} align="center">
                                            Sale price
                                        </TableCell>
                                        <TableCell style={{ fontWeight: "bold" }} align="center">
                                            BuyingPrice
                                        </TableCell>
                                        <TableCell style={{ fontWeight: "bold" }} align="center">
                                            Category
                                        </TableCell>
                                        <TableCell style={{ fontWeight: "bold" }} align="center">
                                            Modify
                                        </TableCell>
                                        <TableCell style={{ fontWeight: "bold" }} align="center">
                                            Delete
                                        </TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {products.length > 0 &&
                                        products.map((row) => (
                                            <TableRow key={row.idProduct}>
                                                <TableCell component="th" scope="row">
                                                    {row.productName}
                                                </TableCell>
                                                <TableCell align="center">
                                                    ${row.salePrice}.00
                                                </TableCell>
                                                <TableCell align="center">${row.buyingPrice}.00</TableCell>
                                                <TableCell align="center">
                                                    {row?.productCategoryNames[0]}
                                                </TableCell>
                                                <TableCell align="center">
                                                    <Link
                                                        to={`/edit/product/${row.id}`}
                                                        className={classes.removeLink}
                                                    >
                                                        <Button
                                                            style={{
                                                                borderRadius: "5px",
                                                                color: "white",
                                                                backgroundColor: "#007bff",
                                                            }}
                                                        >
                                                            Edit
                                                        </Button>
                                                    </Link>
                                                </TableCell>
                                                <TableCell align="center">
                                                    <Button
                                                        style={{
                                                            borderRadius: "5px",
                                                            color: "white",
                                                            backgroundColor: "red",
                                                        }}
                                                        size="small"
                                                        variant="Contained"
                                                        color="secondary"
                                                        onClick={() => deleteProductID(row.id)}
                                                    >
                                                        Remove
                                                    </Button>
                                                </TableCell>
                                            </TableRow>
                                        ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
}
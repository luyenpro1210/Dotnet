import { makeStyles } from "@mui/styles";
import React, { useState } from "react";
import { POST_ADD_TAG } from "../../api/apiService";
import { Navigate } from "react-router-dom";
import { Button, Grid, Paper, TextField, Typography } from "@mui/material";
const useStyles = makeStyles((theme) => {
  const spacing = (value) => `${value * 8}px`; // Define your custom spacing function

  return {
    root: {
      flexGrow: 1,
      marginTop: spacing(2), // Use the custom spacing function
    },
    paper: {
      padding: spacing(2),
      maxWidth: 600,
      margin: "auto",
    },
    title: {
      fontSize: 30,
      textAlign: "center",
    },
    link: {
      padding: spacing(1),
      display: "inline-block",
    },
    txtInput: {
      width: "98%",
      margin: spacing(1),
    },
    submit: {
      margin: `${spacing(3)} 0 ${spacing(2)}`,
    },
  };
});

export default function AddTag() {
  const classes = useStyles();
  const [checkAdd, setCheckAdd] = useState(false);

  const [name, setName] = useState(null);
  const [icon, setIcon] = useState(null)

  const handleChangeName = (e) => {
    setName(e.target.value);
  };
  const handleChangeIcon = (e) => {
    setIcon(e.target.value);
  };


  const addTag = (e) => {
    e.preventDefault();
    if (
      name !== "" &&
      icon !== ""
    ) {
      let tag = {
        tag_name: name,
        icon,
      };
      console.log("tag add", tag);
      POST_ADD_TAG(`Tag`, tag).then((item) => {
        console.log("item", item);
        if (item.data === 1) {
          setCheckAdd(true);
        }
      });
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkAdd) {
    return <Navigate to="/admin/tags" />;
  }
  
  return (
    <>
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography className={classes.title} variant="h4">
              Add Tag
            </Typography>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Tag Name
                </Typography>
                <TextField
                  id="Name"
                  onChange={handleChangeName}
                  name="Name"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                />
              </Grid>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Icon
                </Typography>
                <TextField
                  id="Icon"
                  onChange={handleChangeIcon}
                  name="Icon"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                />
              </Grid>
              
              <Grid item xs={12}>
                <Button
                  type="button"
                  onClick={addTag}
                  className={classes.submit}
                  fullWidth
                  variant="contained"
                  color="primary"
                >
                  Add tag
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </div>
    </>
  );
}

import React, { Component } from "react";
import { withRouter } from "react-router-dom";

import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Link from "@material-ui/core/Link";
import Grid from "@material-ui/core/Grid";
import Box from "@material-ui/core/Box";
import LockOutlinedIcon from "@material-ui/icons/LockOutlined";
import Typography from "@material-ui/core/Typography";
import { withStyles } from "@material-ui/styles";
import Container from "@material-ui/core/Container";
import Divider from "@material-ui/core/Divider";

import api from "../services/api";

const styles = theme => ({
  "@global": {
    body: {
      backgroundColor: theme.palette.common.white
    }
  },
  paper: {
    marginTop: theme.spacing(8),
    display: "flex",
    flexDirection: "column",
    alignItems: "center"
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(1)
  },
  submit: {
    margin: theme.spacing(3, 0, 2)
  }
});

class SignIn extends Component {
  constructor() {
    super();
    this.state = {
      nif: "",
      senha: "",
      error: ""
    };
  }

  efetuarLogin = async event => {
    event.preventDefault();

    const { nif, senha } = this.state;

    await api
      .post("/login", { nif, senha })
      .then(response => {
        if (response.status === 200) {
          console.log(response.data.token);
          localStorage.setItem("@sas-token", response.data.token);
          this.props.history.push("/dashboard");
        } else {
          this.setState({ error: "Verifique suas credenciais." });
        }
      })
      .catch(erro => {
        console.log(erro);
        this.setState({
          error: "Um erro ocorreu. Verifique suas credenciais."
        });
      });
  };

  render() {
    const { classes } = this.props;
    return (
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <div className={classes.paper}>
          <Avatar className={classes.avatar}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            SAS
          </Typography>
          <form
            method="POST"
            className={classes.form}
            noValidate
            onSubmit={this.efetuarLogin}
          >
            {this.state.error && <p>{this.state.error}</p>}
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              type="nif"
              id="nif"
              label="NIF"
              name="nif"
              autoComplete="nif"
              autoFocus
              onChange={e => this.setState({ nif: e.target.value })}
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              name="senha"
              label="Senha"
              type="senha"
              id="senha"
              onChange={e => this.setState({ senha: e.target.value })}
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              className={classes.submit}
            >
              login
            </Button>
            <Divider style={{ margin: "10px 0 10px 0" }} />
            <Grid
              container
              spacing={0}
              direction="column"
              alignItems="center"
              justify="center"
            >
              <Grid item xs>
                <Link href="#" variant="body2">
                  Recuperar Senha
                </Link>
              </Grid>
            </Grid>
          </form>
        </div>
      </Container>
      // <form onSubmit={this.efetuarLogin}>
      //   {this.state.error && <p>{this.state.error}</p>}
      //   <input
      //     type="nif"
      //     placeholder="NIF"
      //     onChange={e => this.setState({ nif: e.target.value })}
      //   />
      //   <input
      //     type="senha"
      //     placeholder="Senha"
      //     onChange={e => this.setState({ senha: e.target.value })}
      //   />
      //   <button type="submit">Entrar</button>
      // </form>
    );
  }
}

export default withRouter(withStyles(styles)(SignIn));
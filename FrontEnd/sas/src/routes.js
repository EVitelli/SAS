import React from "react";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

import { isAuthenticated } from "./services/auth";

import SignIn from "./pages/signin";
import Dashboard from "./pages/admin/dashboard";

const RotaPrivada = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={props =>
      isAuthenticated() ? (
        <Component {...props} />
      ) : (
        <Redirect to={{ pathname: "/", state: { from: props.location } }} />
      )
    }
  />
);

const Routes = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={SignIn} />
      {/* <RotaPrivada path="/home" component={() => <h1>App</h1>} /> */}
      <RotaPrivada path="/dashboard" component={Dashboard} />
      <Route path="*" component={() => <h1>Página Não Encontrada</h1>} />
    </Switch>
  </BrowserRouter>
);

export default Routes;

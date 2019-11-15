// react
import React, { Component } from "react";
import { Switch, Route, Redirect } from "react-router";
import { Link } from "react-router-dom";

// componentes
import Ambientes from "./ambientes";
import Categorias from "./categorias";

import Rodape from "../../components/rodape";

// material
import clsx from "clsx";
import { withStyles } from "@material-ui/core/styles";
import CssBaseline from "@material-ui/core/CssBaseline";
import Drawer from "@material-ui/core/Drawer";
import Grid from "@material-ui/core/Grid";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import List from "@material-ui/core/List";
import Typography from "@material-ui/core/Typography";
import Divider from "@material-ui/core/Divider";
import IconButton from "@material-ui/core/IconButton";
import Container from "@material-ui/core/Container";
import MenuIcon from "@material-ui/icons/Menu";
import ChevronLeftIcon from "@material-ui/icons/ChevronLeft";

import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import DashboardIcon from "@material-ui/icons/Dashboard";
import CalendarToday from "@material-ui/icons/CalendarToday";
import PeopleIcon from "@material-ui/icons/People";
import BarChartIcon from "@material-ui/icons/BarChart";
import DoneAll from "@material-ui/icons/DoneAll";

import ListSubheader from "@material-ui/core/ListSubheader";
import AssignmentIcon from "@material-ui/icons/Assignment";

const drawerWidth = 240;

const styles = theme => ({
  root: {
    display: "flex"
  },
  toolbar: {
    paddingRight: 24 // keep right padding when drawer closed
  },
  toolbarIcon: {
    display: "flex",
    alignItems: "center",
    justifyContent: "flex-end",
    padding: "0 8px",
    ...theme.mixins.toolbar
  },
  appBar: {
    zIndex: theme.zIndex.drawer + 1,
    transition: theme.transitions.create(["width", "margin"], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen
    })
  },
  appBarShift: {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(["width", "margin"], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen
    })
  },
  menuButton: {
    marginRight: 36
  },
  menuButtonHidden: {
    display: "none"
  },
  title: {
    flexGrow: 1
  },
  drawerPaper: {
    position: "relative",
    whiteSpace: "nowrap",
    width: drawerWidth,
    transition: theme.transitions.create("width", {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen
    })
  },
  drawerPaperClose: {
    overflowX: "hidden",
    transition: theme.transitions.create("width", {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen
    }),
    width: theme.spacing(7),
    [theme.breakpoints.up("sm")]: {
      width: theme.spacing(9)
    }
  },
  appBarSpacer: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    height: "100vh",
    overflow: "auto"
  },
  container: {
    paddingTop: theme.spacing(4),
    paddingBottom: theme.spacing(4)
  },
  paper: {
    padding: theme.spacing(2),
    display: "flex",
    overflow: "auto",
    flexDirection: "column"
  },
  fixedHeight: {
    height: 240
  }
});

class Dashboard extends Component {
  constructor() {
    super();
    this.state = { open: true };
  }

  handleDrawerOpen = () => {
    this.setState({ open: true });
  };
  handleDrawerClose = () => {
    this.setState({ open: false });
  };

  render() {
    const { classes } = this.props;
    return (
      // <React.Fragment>
      //   <h1>Dashboard</h1>
      //   <ul>
      //     <li>
      //       <Link to={`${this.props.match.path}/ambientes`}>Ambientes</Link>
      //       <Link to={`${this.props.match.path}/categorias`}>Categorias</Link>
      //     </li>
      //   </ul>

      //   <Switch>
      //     <Route
      //       path={`${this.props.match.path}/ambientes`}
      //       component={Ambientes}
      //     />
      //     <Route
      //       path={`${this.props.match.path}/categorias`}
      //       component={Categorias}
      //     />
      //     <Redirect from="*" to="/dashboard" />
      //   </Switch>
      // </React.Fragment>

      <div className={classes.root}>
        <CssBaseline />
        <AppBar
          position="absolute"
          className={clsx(
            classes.appBar,
            this.state.open && classes.appBarShift
          )}
        >
          <Toolbar className={classes.toolbar}>
            <IconButton
              edge="start"
              color="inherit"
              aria-label="open drawer"
              onClick={this.handleDrawerOpen}
              className={clsx(
                classes.menuButton,
                this.state.open && classes.menuButtonHidden
              )}
            >
              <MenuIcon />
            </IconButton>
            <Typography
              component="h1"
              variant="h6"
              color="inherit"
              noWrap
              className={classes.title}
            >
              Dashboard
            </Typography>
          </Toolbar>
        </AppBar>
        <Drawer
          variant="permanent"
          classes={{
            paper: clsx(
              classes.drawerPaper,
              !this.state.open && classes.drawerPaperClose
            )
          }}
          open={this.state.open}
        >
          <div className={classes.toolbarIcon}>
            SAS
            <IconButton onClick={this.handleDrawerClose}>
              <ChevronLeftIcon />
            </IconButton>
          </div>
          <Divider />
          <List>
            {" "}
            <div>
              <ListItem
                button
                component={Link}
                to={`${this.props.match.path}/`}
              >
                <ListItemIcon>
                  <DashboardIcon />
                </ListItemIcon>
                <ListItemText primary="Dashboard" />
              </ListItem>
              <ListItem
                button
                component={Link}
                to={`${this.props.match.path}/agendamentos`}
              >
                <ListItemIcon>
                  <CalendarToday />
                </ListItemIcon>
                <ListItemText primary="Agendamentos" />
              </ListItem>
              <ListItem
                button
                component={Link}
                to={`${this.props.match.path}/ambientes`}
              >
                <ListItemIcon>
                  <DoneAll />
                </ListItemIcon>
                <ListItemText primary="Ambientes" />
              </ListItem>
              <ListItem
                button
                component={Link}
                to={`${this.props.match.path}/categorias`}
              >
                <ListItemIcon>
                  <BarChartIcon />
                </ListItemIcon>
                <ListItemText primary="Categorias" />
              </ListItem>
              <ListItem
                button
                component={Link}
                to={`${this.props.match.path}/participantes`}
              >
                <ListItemIcon>
                  <PeopleIcon />
                </ListItemIcon>
                <ListItemText primary="Participantes" />
              </ListItem>
            </div>
          </List>
          <Divider />
          <List>
            <ListSubheader inset>Administração</ListSubheader>
            <ListItem button>
              <ListItemIcon>
                <AssignmentIcon />
              </ListItemIcon>
              <ListItemText primary="Usuários" />
            </ListItem>
          </List>
        </Drawer>
        <main className={classes.content}>
          <div className={classes.appBarSpacer} />
          <Container maxWidth="lg" className={classes.container}>
            <Grid>
              <Switch>
                <Route
                  path={`${this.props.match.path}/ambientes`}
                  component={Ambientes}
                />
                <Route
                  path={`${this.props.match.path}/categorias`}
                  component={Categorias}
                />
                <Redirect from="*" to="/dashboard" />
              </Switch>
            </Grid>
          </Container>
          <Rodape />
        </main>
      </div>
    );
  }
}

export default withStyles(styles)(Dashboard);
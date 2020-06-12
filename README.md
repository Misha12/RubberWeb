# RubberWeb

RubberWeb is web UI for [RubberGod](https://github.com/Toaster192/rubbergod) karma system.

## Requirements:

- .NET Core 3.1
- [Angular CLI](https://cli.angular.io/)
- RubberGod database and [GrillBot](https://github.com/Misha12/GrillBot) instance.

Microsoft Visual Studio 2019 (Recomended).

## Systemd unit file

```
[Unit]
Description=RubberWeb
After=network.target

[Service]
ExecStart=/path/to/RubberWeb {port}
Restart=on-failure
WorkingDirectory=-/path/to/RubberWeb
Environment="LANG=cs_CZ.UTF-8"

[Install]
WantedBy=multi-user.target
```

- Port is optional. Default value is 5000.

## Licence

This project is licensed under the GNU GPL v.3 License.

仅供学习参考，bug较多。

1.12的forge版本需要先创建launcher_profiles.json,再自行安装forge。1.12需要自行补全依赖库（5-6个jar）还需要复制一下native文件夹到forge文件夹中，需要对应改名和-Djava path的对应。

launcher_profiles.json的内容：
{"selectedProfile": "(Default)","profiles": {"(Default)": {"name": "(Default)"}},"clientToken": "88888888-8888-8888-8888-888888888888"}

Form1.cs里面可以改debug模式。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.BL
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IFileManager _fileManager;
        private readonly IMessageService _messageService;

        private String _currentFilePath;

        public MainPresenter(IMainForm view, IFileManager fileManager, IMessageService messageService)
        {
            _view = view;
            _fileManager = fileManager;
            _messageService = messageService;

            _view.SetSymbolCount(0);

            _view.ContentChanged += new EventHandler(_view.ContentChanged);
            _view.FileOpenClick += new EventHandler(_view_FileOpenClick);
            _view.FileSaveClick += new EventHandler(_view_FileSaveClick);
        }

        void _view_ContentChanged(object sender, EventArgs e)
        {
            string content=_view.Content;
            int count=_manager.GetSymbolCount(content);
            _view.SetSymbolCount(count);
        }
        void _view_FileOpenClick(object sender, EventArgs e)
        { 
            try
            {
                string filePath = _view.FilePath;
                bool IsExist = _manager.IsExist(filePath);
                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбранный файл не существует.");
                    return;
                }
                _currentFilePath = filePath;
                int count = _manager.GetSymbolCount(content);

                _view.Content = content;
                _view.SetSymbolCount(count);

            }
            catch (Exception ex)
            {
                
                _messageService.ShowError(ex.Message);
            }
        }
        void _view_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;

                _manager.SaveContent(content, _currentFilePath);

                _messageService.ShowMessage("Файл успешно сохранён.");
            }
            catch (Exception ex)
            {

                _messageService.ShowError(ex.Message);
            }
        }
        
    }
}
